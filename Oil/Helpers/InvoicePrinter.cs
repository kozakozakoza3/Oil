using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Oil.Models;

namespace Oil.Helpers
{
    public class InvoicePrinter
    {
        private readonly string _storagePath;

        public InvoicePrinter(string storagePath = null)
        {
            // Если путь не указан, используем стандартный
            _storagePath = storagePath ?? Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Invoices"
            );

            // Создаем папку, если она не существует
            Directory.CreateDirectory(_storagePath);
        }

        public Image LoadInvoice(int invoiceId, int routeId)
        {
            try
            {
                // 1. Получаем путь из БД через DbMethods
                var parameters = new Dictionary<string, object>
                {
                    { "@invoiceId", invoiceId },
                    { "@routeId", routeId }
                };

                string sql = @"
                    SELECT Consignment_invoice 
                    FROM Invoice_route 
                    WHERE Invoice_id = @invoiceId 
                    AND Route_id = @routeId";

                DataTable dt = DbMethods.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Товарно-транспортная накладная не найдена в базе данных", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                // 2. Получаем путь через SafeConverter
                string filePath = SafeConverter.ToString(dt.Rows[0]["Consignment_invoice"]);

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Путь к файлу не указан в БД", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // 3. Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Файл накладной не найден:\n{filePath}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // 4. Загружаем изображение
                return Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке накладной:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Печатать накладную
        public bool ShowPrintDialog(InvoicePrintData data)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (sender, e) => PrintInvoicePage(e, data);

                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDoc,
                    AllowSomePages = true,
                    AllowSelection = true
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show("Товарно-транспортная накладная отправлена на печать!", "Готово",
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

        // Удалить накладную
        public bool DeleteInvoice(int invoiceId, int routeId)
        {
            try
            {
                // 1. Получаем путь из БД
                var parameters = new Dictionary<string, object>
                {
                    { "@invoiceId", invoiceId },
                    { "@routeId", routeId }
                };

                string sql = @"
                    SELECT Consignment_invoice 
                    FROM Invoice_route 
                    WHERE Invoice_id = @invoiceId 
                    AND Route_id = @routeId";

                DataTable dt = DbMethods.GetData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    string filePath = SafeConverter.ToString(dt.Rows[0]["Consignment_invoice"]);

                    // 2. Удаляем файл, если он существует
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }

                // 3. Удаляем запись из БД через DbMethods.Delete
                bool success = DbMethods.Delete("Invoice_route", invoiceId);

                if (success)
                {
                    MessageBox.Show("Товарно-транспортная накладная удалена", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении накладной:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Проверить, существует ли накладная
        public bool InvoiceExists(int invoiceId, int routeId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@invoiceId", invoiceId },
                { "@routeId", routeId }
            };

            string sql = @"
                SELECT COUNT(*) 
                FROM Invoice_route 
                WHERE Invoice_id = @invoiceId 
                AND Route_id = @routeId 
                AND Consignment_invoice IS NOT NULL";

            object result = DbMethods.ExecuteScalar(sql, parameters);
            return SafeConverter.ToInt(result) > 0;
        }

        // Получить путь к существующей накладной
        public string GetInvoicePath(int invoiceId, int routeId)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@invoiceId", invoiceId },
                    { "@routeId", routeId }
                };

                string sql = @"
                    SELECT Consignment_invoice 
                    FROM Invoice_route 
                    WHERE Invoice_id = @invoiceId 
                    AND Route_id = @routeId";

                DataTable dt = DbMethods.GetData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    return SafeConverter.ToString(dt.Rows[0]["Consignment_invoice"]);
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении пути к накладной:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Сохранить накладную в файл
        public bool SaveInvoiceToFile(InvoicePrintData data, string filePath)
        {
            try
            {
                using (Bitmap bitmap = GenerateInvoiceImage(data))
                {
                    bitmap.Save(filePath, ImageFormat.Png);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении накладной в файл:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Создать изображение накладной
        private Bitmap GenerateInvoiceImage(InvoicePrintData data)
        {
            Bitmap bitmap = new Bitmap(800, 1120);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, 800, 1120);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                int y = 50;
                PrintInvoicePageContent(g, data, ref y);
            }
            return bitmap;
        }

        // Показать изображение в отдельном окне
        public void ShowImageInViewer(Image image, string title)
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

        #region Методы печати

        // Печатает одну страницу товарно-транспортной накладной
        private void PrintInvoicePage(PrintPageEventArgs e, InvoicePrintData data)
        {
            Graphics g = e.Graphics;
            int y = 50;

            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font subtitleFont = new Font("Arial", 12, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            // Заголовок
            DrawCenteredString(g, "ТОВАРНО-ТРАНСПОРТНАЯ НАКЛАДНАЯ", titleFont, y);
            y += 30;
            DrawCenteredString(g, $"№ {data.InvoiceNumber} от {data.InvoiceDate:dd.MM.yyyy}", subtitleFont, y);
            y += 40;

            DrawLine(g, y, 3);
            y += 30;

            // Информация о грузе
            y = DrawProductInfo(g, data, y);
            y += 20;

            DrawLine(g, y);
            y += 20;

            // Информация о грузоотправителе и грузополучателе
            y = DrawCounterpartiesInfo(g, data, y);
            y += 20;

            DrawLine(g, y);
            y += 20;

            // Транспортная информация
            y = DrawTransportInfo(g, data, y);
            y += 20;

            DrawLine(g, y);
            y += 20;

            // Информация о маршруте
            y = DrawRouteInfo(g, data, y);
            y += 20;

            DrawLine(g, y);
            y += 30;

            // Ответственные лица и подписи
            y = DrawSignatures(g, data, y);
        }

        // Информация о грузе
        private int DrawProductInfo(Graphics g, InvoicePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            g.DrawString("1. ХАРАКТЕРИСТИКА ГРУЗА", headerFont, Brushes.Black, 50, y);
            y += 25;

            DrawInfoRow(g, "Наименование груза:", $"{data.ProductName} {data.ProductMark}", 70, ref y);
            DrawInfoRow(g, "Класс опасности:", "3 (Горючие жидкости)", 70, ref y);
            DrawInfoRow(g, "Код ОКПД2:", "19.20.11.110", 70, ref y);
            DrawInfoRow(g, "Количество груза:", data.LotSize, 70, ref y);
            DrawInfoRow(g, "Вид упаковки:", "Налив", 70, ref y);
            DrawInfoRow(g, "Способ определения массы:", "По стандарту ГОСТ 3900-85", 70, ref y);

            return y;
        }

        // Информация о грузоотправителе и грузополучателе
        private int DrawCounterpartiesInfo(Graphics g, InvoicePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            g.DrawString("2. ГРУЗООТПРАВИТЕЛЬ И ГРУЗОПОЛУЧАТЕЛЬ", headerFont, Brushes.Black, 50, y);
            y += 25;

            // Грузоотправитель
            g.DrawString("Грузоотправитель:", boldFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawString("ООО 'НЕФТЯНАЯ КОМПАНИЯ'", normalFont, Brushes.Black, 90, y);
            y += 20;
            g.DrawString($"Адрес: {data.StartingPoint}", normalFont, Brushes.Black, 90, y);
            y += 20;
            g.DrawString("ИНН: 7701234567, КПП: 770101001, ОГРН: 1027700132195", normalFont, Brushes.Black, 90, y);
            y += 30;

            // Грузополучатель
            g.DrawString("Грузополучатель:", boldFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawString(data.CounterpartyName, normalFont, Brushes.Black, 90, y);
            y += 20;
            g.DrawString($"Адрес: {data.Destination}", normalFont, Brushes.Black, 90, y);
            y += 20;
            g.DrawString($"Расстояние: {data.Distance}", normalFont, Brushes.Black, 90, y);

            return y + 10;
        }

        // Транспортная информация
        private int DrawTransportInfo(Graphics g, InvoicePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            g.DrawString("3. ТРАНСПОРТНЫЕ СРЕДСТВА", headerFont, Brushes.Black, 50, y);
            y += 25;

            DrawInfoRow(g, "Вид транспорта:", "Железнодорожный", 70, ref y);
            DrawInfoRow(g, "Поезд:", data.TrainName, 70, ref y);
            DrawInfoRow(g, "Тип вагонов:", "Цистерны модели 15-1500", 70, ref y);
            DrawInfoRow(g, "Количество вагонов:", "15 шт.", 70, ref y);
            DrawInfoRow(g, "Номера вагонов:", "45678901-45678915", 70, ref y);

            return y;
        }

        // Информация о маршруте
        private int DrawRouteInfo(Graphics g, InvoicePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            g.DrawString("4. МАРШРУТ СЛЕДОВАНИЯ", headerFont, Brushes.Black, 50, y);
            y += 25;

            DrawInfoRow(g, "Пункт отправления:", data.StartingPoint, 70, ref y);
            DrawInfoRow(g, "Пункт назначения:", data.Destination, 70, ref y);
            DrawInfoRow(g, "Статус маршрута:", data.RouteStatus, 70, ref y);

            if (data.SendingDate.HasValue)
            {
                DrawInfoRow(g, "Дата отправления:", data.SendingDate.Value.ToString("dd.MM.yyyy HH:mm"), 70, ref y);
            }

            if (data.ArrivalDate.HasValue)
            {
                DrawInfoRow(g, "Дата прибытия:", data.ArrivalDate.Value.ToString("dd.MM.yyyy HH:mm"), 70, ref y);
            }

            return y;
        }

        // Подписи и ответственные лица
        private int DrawSignatures(Graphics g, InvoicePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 9);

            g.DrawString("5. ОТВЕТСТВЕННЫЕ ЛИЦА И ПОДПИСИ", headerFont, Brushes.Black, 50, y);
            y += 25;

            // Грузоотправитель
            g.DrawString("Грузоотправитель:", normalFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawLine(Pens.Black, 70, y, 270, y);
            y += 15;
            g.DrawString("(подпись, должность, ФИО)", smallFont, Brushes.Black, 70, y);
            y += 30;

            // Грузополучатель
            g.DrawString("Грузополучатель:", normalFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawLine(Pens.Black, 70, y, 270, y);
            y += 15;
            g.DrawString($"{data.CounterpartyName}", smallFont, Brushes.Black, 70, y);
            y += 30;

            // Перевозчик
            g.DrawString("Перевозчик:", normalFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawLine(Pens.Black, 70, y, 270, y);
            y += 15;
            g.DrawString("ООО 'Железнодорожные перевозки'", smallFont, Brushes.Black, 70, y);
            y += 30;

            // Составитель накладной
            g.DrawString("Составитель накладной:", normalFont, Brushes.Black, 70, y);
            y += 20;
            g.DrawString($"{data.EmployeeName}, {data.EmployeePosition}", normalFont, Brushes.Black, 90, y);
            y += 20;
            g.DrawLine(Pens.Black, 70, y, 270, y);
            y += 15;
            g.DrawString("(подпись)", smallFont, Brushes.Black, 70, y);
            y += 40;

            // Дата и время создания документа
            g.DrawString($"Документ создан: {data.PrintDateTime:dd.MM.yyyy HH:mm}", smallFont, Brushes.Black, 50, y);

            return y;
        }

        // Вспомогательные методы для рисования
        private void DrawCenteredString(Graphics g, string text, Font font, int y)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(0, y, 800, font.Height);
            g.DrawString(text, font, Brushes.Black, rect, format);
        }

        private void DrawLine(Graphics g, int y, int thickness = 1)
        {
            using (Pen pen = new Pen(Color.Black, thickness))
            {
                g.DrawLine(pen, 50, y, 750, y);
            }
        }

        private void DrawInfoRow(Graphics g, string label, string value, int x, ref int y)
        {
            Font normalFont = new Font("Arial", 11);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            g.DrawString(label, boldFont, Brushes.Black, x, y);

            // Рассчитываем ширину текста для выравнивания
            SizeF labelSize = g.MeasureString(label, boldFont);
            int valueX = x + (int)labelSize.Width + 10;

            g.DrawString(value, normalFont, Brushes.Black, valueX, y);
            y += 20;
        }

        // Содержимое накладной (для генерации изображения)
        private void PrintInvoicePageContent(Graphics g, InvoicePrintData data, ref int y)
        {
            // Используем те же методы, что и для печати
            y = DrawProductInfo(g, data, y);
            y += 20;
            DrawLine(g, y);
            y += 20;

            y = DrawCounterpartiesInfo(g, data, y);
            y += 20;
            DrawLine(g, y);
            y += 20;

            y = DrawTransportInfo(g, data, y);
            y += 20;
            DrawLine(g, y);
            y += 20;

            y = DrawRouteInfo(g, data, y);
            y += 20;
            DrawLine(g, y);
            y += 30;

            y = DrawSignatures(g, data, y);
        }

        #endregion
    }
}