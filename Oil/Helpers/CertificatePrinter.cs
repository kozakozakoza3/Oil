using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Oil.Helpers
{
    public class CertificatePrinter
    {
        // Показывает диалог печати
        public void ShowPrintDialog(CertificatePrintData data)
        {
            try
            {
                // Создаем документ для печати
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (sender, e) => PrintCertificatePage(e, data);

                // Создаем диалог печати
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;

                // Показываем диалог
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Печатаем
                    printDoc.Print();
                    MessageBox.Show("Сертификат отправлен на печать!", "Готово");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}");
            }
        }

        // Печатает одну страницу
        private void PrintCertificatePage(PrintPageEventArgs e, CertificatePrintData data)
        {
            Graphics g = e.Graphics;
            int y = 50; // Начальная позиция

            // Шрифты
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font smallFont = new Font("Arial", 10);

            // 1. Заголовок
            DrawCenteredString(g, "СЕРТИФИКАТ АНАЛИЗА", titleFont, y);
            y += 40;

            // 2. Номер и дата
            g.DrawString($"№ {data.AnalysisId} от {data.CertificateDateTime:dd.MM.yyyy}",
                        headerFont, Brushes.Black, 100, y);
            y += 40;

            // Линия
            DrawLine(g, y);
            y += 30;

            // 3. Информация о продукте
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

            // Линия
            DrawLine(g, y);
            y += 30;

            // 4. Результаты анализа
            g.DrawString("Результаты анализа:", headerFont, Brushes.Black, 100, y);
            y += 25;

            // Таблица результатов
            y = DrawTable(g, data, y);

            // Линия
            DrawLine(g, y);
            y += 30;

            // 5. Аналитик
            y = DrawAnalystInfo(g, data, y);

            // 6. Время печати
            g.DrawString($"Сертификат напечатан: {DateTime.Now:dd.MM.yyyy HH:mm}",
                        smallFont, Brushes.Black, 100, y);
        }

        // Метод для рисования линии
        private void DrawLine(Graphics g, int y)
        {
            g.DrawLine(Pens.Black, 100, y, 700, y);
        }

        // Метод для центрирования текста
        private void DrawCenteredString(Graphics g, string text, Font font, int y)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            RectangleF rect = new RectangleF(0, y, 800, font.Height);
            g.DrawString(text, font, Brushes.Black, rect, format);
        }

        // Метод для рисования таблицы
        private int DrawTable(Graphics g, CertificatePrintData data, int y)
        {
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);

            // Заголовок таблицы
            g.DrawString("Показатель", headerFont, Brushes.Black, 120, y);
            g.DrawString("Значение", headerFont, Brushes.Black, 350, y);
            g.DrawString("Ед.изм.", headerFont, Brushes.Black, 550, y);
            y += 25;

            // Данные таблицы
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

        // Метод для рисования строки таблицы
        private int DrawTableRow(Graphics g, string parameter, string value,
                               string unit, int y)
        {
            Font normalFont = new Font("Arial", 11);

            g.DrawString(parameter, normalFont, Brushes.Black, 120, y);
            g.DrawString(value, normalFont, Brushes.Black, 350, y);
            g.DrawString(unit, normalFont, Brushes.Black, 550, y);

            return y + 25;
        }

        // Метод для рисования информации об аналитике
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

            // Подпись
            g.DrawLine(Pens.Black, 100, y, 300, y);
            y += 15;
            g.DrawString("(подпись)", smallFont, Brushes.Black, 100, y);
            y += 30;

            return y;
        }
    }
}