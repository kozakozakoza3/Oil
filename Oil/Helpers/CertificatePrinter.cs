using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Oil.Helpers
{
    public class CertificatePrinter
    {
        private readonly string _storagePath;

        public CertificatePrinter(string storagePath = null)
        {
            // Если путь не указан, используем стандартный
            _storagePath = storagePath ?? Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Certificates"
            );

            // Создаем папку, если она не существует
            Directory.CreateDirectory(_storagePath);
        }

        // Сохранить сертификат в файл и путь в БД
        public bool SaveCertificate(CertificatePrintData data, int laboratoryAnalysisId, int routeId)
        {
            try
            {
                // 1. Генерируем уникальное имя файла
                string fileName = $"cert_{laboratoryAnalysisId}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string filePath = Path.Combine(_storagePath, fileName);

                // 2. Создаем и сохраняем изображение
                using (Bitmap certificateImage = GenerateCertificateImage(data))
                {
                    certificateImage.Save(filePath, ImageFormat.Png);
                }

                // 3. Сохраняем путь в БД через DbMethods
                var parameters = new Dictionary<string, object>
                {
                    { "@labId", laboratoryAnalysisId },
                    { "@routeId", routeId },
                    { "@path", filePath }
                };

                string sql = @"
                    INSERT INTO Laboratory_analysis_route 
                    (Laboratory_analysis_id, Route_id, Certificate_analysis) 
                    VALUES (@labId, @routeId, @path)
                    ON CONFLICT (Laboratory_analysis_id, Route_id) 
                    DO UPDATE SET Certificate_analysis = @path";

                bool success = DbMethods.Execute(sql, parameters);

                if (success)
                {
                    MessageBox.Show($"Сертификат сохранен:\n{filePath}", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении в БД", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сертификата:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Загрузить сертификат из БД и вернуть изображение
        public Image LoadCertificate(int laboratoryAnalysisId, int routeId)
        {
            try
            {
                // 1. Получаем путь из БД через DbMethods
                var parameters = new Dictionary<string, object>
                {
                    { "@labId", laboratoryAnalysisId },
                    { "@routeId", routeId }
                };

                string sql = @"
                    SELECT Certificate_analysis 
                    FROM Laboratory_analysis_route 
                    WHERE Laboratory_analysis_id = @labId 
                    AND Route_id = @routeId";

                DataTable dt = DbMethods.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Сертификат не найден в базе данных", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                // 2. Получаем путь через SafeConverter
                string filePath = SafeConverter.ToString(dt.Rows[0]["Certificate_analysis"]);

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Путь к файлу не указан в БД", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // 3. Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Файл сертификата не найден:\n{filePath}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // 4. Загружаем изображение
                return Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сертификата:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Показать сертификат в окне просмотра
        public void ShowCertificate(CertificatePrintData data, int laboratoryAnalysisId, int routeId)
        {
            // Вариант 1: Загрузить существующий
            Image certificate = LoadCertificate(laboratoryAnalysisId, routeId);

            if (certificate != null)
            {
                ShowImageInViewer(certificate, "Просмотр сертификата");
            }
            else
            {
                // Вариант 2: Создать новый и показать
                using (Bitmap newCertificate = GenerateCertificateImage(data))
                {
                    ShowImageInViewer(newCertificate, "Предварительный просмотр сертификата");
                }
            }
        }

        // Печатать сертификат
        public bool ShowPrintDialog(CertificatePrintData data)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (sender, e) => PrintCertificatePage(e, data);

                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDoc,
                    AllowSomePages = true,
                    AllowSelection = true
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show("Сертификат отправлен на печать!", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Удалить сертификат
        public bool DeleteCertificate(int laboratoryAnalysisId, int routeId)
        {
            try
            {
                // 1. Получаем путь из БД
                var parameters = new Dictionary<string, object>
                {
                    { "@labId", laboratoryAnalysisId },
                    { "@routeId", routeId }
                };

                string sql = @"
                    SELECT Certificate_analysis 
                    FROM Laboratory_analysis_route 
                    WHERE Laboratory_analysis_id = @labId 
                    AND Route_id = @routeId";

                DataTable dt = DbMethods.GetData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    string filePath = SafeConverter.ToString(dt.Rows[0]["Certificate_analysis"]);

                    // 2. Удаляем файл, если он существует
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                // 3. Удаляем запись из БД через DbMethods.Delete
                bool success = DbMethods.Delete("Laboratory_analysis_route", laboratoryAnalysisId);

                if (success)
                {
                    MessageBox.Show("Сертификат удален", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении сертификата:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Проверить, существует ли сертификат
        public bool CertificateExists(int laboratoryAnalysisId, int routeId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@labId", laboratoryAnalysisId },
                { "@routeId", routeId }
            };

            string sql = @"
                SELECT COUNT(*) 
                FROM Laboratory_analysis_route 
                WHERE Laboratory_analysis_id = @labId 
                AND Route_id = @routeId 
                AND Certificate_analysis IS NOT NULL";

            object result = DbMethods.ExecuteScalar(sql, parameters);
            return SafeConverter.ToInt(result) > 0;
        }

        // Получить путь к существующему сертификату
        public string GetCertificatePath(int laboratoryAnalysisId, int routeId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@labId", laboratoryAnalysisId },
                { "@routeId", routeId }
            };

            string sql = @"
                SELECT Certificate_analysis 
                FROM Laboratory_analysis_route 
                WHERE Laboratory_analysis_id = @labId 
                AND Route_id = @routeId";

            DataTable dt = DbMethods.GetData(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                return SafeConverter.ToString(dt.Rows[0]["Certificate_analysis"]);
            }

            return string.Empty;
        }

        #region Вспомогательные методы

        // Генерация изображения сертификата
        private Bitmap GenerateCertificateImage(CertificatePrintData data)
        {
            Bitmap bitmap = new Bitmap(800, 1120);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, 800, 1120);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                int y = 50;
                PrintCertificatePageContent(g, data, ref y);
            }
            return bitmap;
        }

        // Показать изображение в отдельном окне
        private void ShowImageInViewer(Image image, string title)
        {
            Form viewerForm = new Form
            {
                Text = title,
                Size = new Size(850, 1200),
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = true,
                MinimizeBox = true
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            // Кнопка закрытия
            Button btnClose = new Button
            {
                Text = "Закрыть",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnClose.Click += (s, e) => viewerForm.Close();

            // Кнопка печати
            Button btnPrint = new Button
            {
                Text = "Печать",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnPrint.Click += (s, e) =>
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, ev) =>
                {
                    ev.Graphics.DrawImage(image, ev.PageBounds);
                };

                PrintDialog printDialog = new PrintDialog { Document = pd };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            };

            Panel buttonPanel = new Panel
            {
                Height = 80,
                Dock = DockStyle.Bottom
            };
            buttonPanel.Controls.Add(btnClose);
            buttonPanel.Controls.Add(btnPrint);

            viewerForm.Controls.Add(pictureBox);
            viewerForm.Controls.Add(buttonPanel);
            viewerForm.ShowDialog();
        }

        #endregion

        #region Методы печати (остаются без изменений)

        // Печатает одну страницу
        private void PrintCertificatePage(PrintPageEventArgs e, CertificatePrintData data)
        {
            Graphics g = e.Graphics;
            int y = 50;

            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 10);

            DrawCenteredString(g, "СЕРТИФИКАТ АНАЛИЗА", titleFont, y);
            y += 40;

            g.DrawString($"№ {data.AnalysisId} от {data.CertificateDateTime:dd.MM.yyyy}",
                        headerFont, Brushes.Black, 100, y);
            y += 40;

            DrawLine(g, y);
            y += 30;

            PrintCertificatePageContent(g, data, ref y);
        }

        // Содержимое сертификата
        private void PrintCertificatePageContent(Graphics g, CertificatePrintData data, ref int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 10);

            // Информация о продукте
            g.DrawString("Информация о продукте:", headerFont, Brushes.Black, 100, y);
            y += 25;

            g.DrawString($"Наименование: {data.ProductName}", normalFont, Brushes.Black, 120, y);
            y += 20;

            g.DrawString($"Марка: {data.ProductMark}", normalFont, Brushes.Black, 120, y);
            y += 20;

            g.DrawString($"Объем пробы: {data.SampleVolume} {data.UnitOfMeasureVolume}",
                        normalFont, Brushes.Black, 120, y);
            y += 20;

            g.DrawString($"Дата анализа: {data.AnalysisDateTime:dd.MM.yyyy HH:mm}",
                        normalFont, Brushes.Black, 120, y);
            y += 30;

            DrawLine(g, y);
            y += 30;

            // Результаты анализа
            g.DrawString("Результаты анализа:", headerFont, Brushes.Black, 100, y);
            y += 25;

            y = DrawTable(g, data, y);

            DrawLine(g, y);
            y += 30;

            // Аналитик
            y = DrawAnalystInfo(g, data, y);

            // Время создания
            g.DrawString($"Сертификат создан: {DateTime.Now:dd.MM.yyyy HH:mm}",
                        smallFont, Brushes.Black, 100, y);
        }

        private void DrawLine(Graphics g, int y)
        {
            g.DrawLine(Pens.Black, 100, y, 700, y);
        }

        private void DrawCenteredString(Graphics g, string text, Font font, int y)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(0, y, 800, font.Height);
            g.DrawString(text, font, Brushes.Black, rect, format);
        }

        private int DrawTable(Graphics g, CertificatePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);

            g.DrawString("Показатель", headerFont, Brushes.Black, 120, y);
            g.DrawString("Значение", headerFont, Brushes.Black, 350, y);
            g.DrawString("Ед.изм.", headerFont, Brushes.Black, 550, y);
            y += 25;

            y = DrawTableRow(g, "Плотность", data.Density.ToString("F2"),
                           data.UnitOfMeasureDensity, y);
            y = DrawTableRow(g, "Содержание серы", data.SulfurContent.ToString("F2"),
                           data.UnitOfMeasureSulfur, y);
            y = DrawTableRow(g, "Вязкость", data.Viscosity.ToString("F1"),
                           data.UnitOfMeasureViscosity, y);
            y = DrawTableRow(g, "Темп. вспышки", data.FlashPoint.ToString(),
                           data.UnitOfMeasureFlash, y);

            return y;
        }

        private int DrawTableRow(Graphics g, string parameter, string value,
                               string unit, int y)
        {
            Font normalFont = new Font("Arial", 11);

            g.DrawString(parameter, normalFont, Brushes.Black, 120, y);
            g.DrawString(value, normalFont, Brushes.Black, 350, y);
            g.DrawString(unit, normalFont, Brushes.Black, 550, y);

            return y + 25;
        }

        private int DrawAnalystInfo(Graphics g, CertificatePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 10);

            g.DrawString("Аналитик:", headerFont, Brushes.Black, 100, y);
            y += 25;

            g.DrawString(data.AnalystName, normalFont, Brushes.Black, 120, y);
            y += 20;

            g.DrawString(data.AnalystPosition, normalFont, Brushes.Black, 120, y);
            y += 30;

            g.DrawLine(Pens.Black, 100, y, 300, y);
            y += 15;
            g.DrawString("(подпись)", smallFont, Brushes.Black, 100, y);
            y += 30;

            return y;
        }
        #endregion
    }
}