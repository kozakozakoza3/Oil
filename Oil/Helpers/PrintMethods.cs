using iTextSharp.text;
using iTextSharp.text.pdf;
using Oil.Models;
using System;
using System.IO;

namespace Oil.Helpers
{
    public class PrintMethods
    {
        public static bool CreateAnalysisCertificate(LaboratoryAnalysis analysis, string filePath)
        {
            try
            {
                // Создаем документ
                Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                document.Open();

                // Заголовок
                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                Paragraph title = new Paragraph("СЕРТИФИКАТ ЛАБОРАТОРНОГО АНАЛИЗА", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                document.Add(title);

                // Информация о продукте
                iTextSharp.text.Font normalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                // Таблица для информации
                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 100;
                infoTable.SetWidths(new float[] { 30f, 70f });

                // Заполняем таблицу
                AddTableCell(infoTable, "Продукт:", boldFont);
                AddTableCell(infoTable, analysis.ProductName, normalFont);

                AddTableCell(infoTable, "Аналитик:", boldFont);
                AddTableCell(infoTable, analysis.AnalystName, normalFont);

                AddTableCell(infoTable, "Дата анализа:", boldFont);
                AddTableCell(infoTable, analysis.DateTimeAnalysis.ToString("dd.MM.yyyy HH:mm"), normalFont);

                AddTableCell(infoTable, "Объем пробы:", boldFont);
                AddTableCell(infoTable, $"{analysis.SampleVolume} {analysis.UnitOfMeasureVolume}", normalFont);

                document.Add(infoTable);
                document.Add(new Paragraph(" "));

                // Заголовок результатов
                Paragraph resultsTitle = new Paragraph("РЕЗУЛЬТАТЫ АНАЛИЗА", boldFont);
                resultsTitle.Alignment = Element.ALIGN_CENTER;
                resultsTitle.SpacingAfter = 15;
                document.Add(resultsTitle);

                // Таблица результатов
                PdfPTable resultsTable = new PdfPTable(3);
                resultsTable.WidthPercentage = 100;
                resultsTable.SetWidths(new float[] { 40f, 30f, 30f });

                // Заголовки таблицы
                AddTableCell(resultsTable, "Показатель", boldFont, true);
                AddTableCell(resultsTable, "Значение", boldFont, true);
                AddTableCell(resultsTable, "Единица измерения", boldFont, true);

                // Данные
                AddTableCell(resultsTable, "Плотность", normalFont);
                AddTableCell(resultsTable, analysis.OilProductDensity.ToString("F1"), normalFont);
                AddTableCell(resultsTable, analysis.UnitOfMeasureDensity, normalFont);

                AddTableCell(resultsTable, "Содержание серы", normalFont);
                AddTableCell(resultsTable, analysis.OilProductSulfurContent.ToString("F2"), normalFont);
                AddTableCell(resultsTable, analysis.UnitOfMeasureSulfur, normalFont);

                AddTableCell(resultsTable, "Содержание воды", normalFont);
                if (analysis.OilProductWaterContent.HasValue)
                {
                    AddTableCell(resultsTable, analysis.OilProductWaterContent.Value.ToString("F3"), normalFont);
                }
                else
                {
                    AddTableCell(resultsTable, "не указано", normalFont);
                }
                AddTableCell(resultsTable, analysis.UnitOfMeasureWater, normalFont);

                AddTableCell(resultsTable, "Вязкость", normalFont);
                AddTableCell(resultsTable, analysis.OilProductViscosity.ToString("F1"), normalFont);
                AddTableCell(resultsTable, analysis.UnitOfMeasureViscosity, normalFont);

                AddTableCell(resultsTable, "Температура вспышки", normalFont);
                AddTableCell(resultsTable, analysis.OilProductFlashPoint.ToString(), normalFont);
                AddTableCell(resultsTable, analysis.UnitOfMeasureFlash, normalFont);

                document.Add(resultsTable);
                document.Add(new Paragraph(" "));

                // Подвал
                Paragraph footer = new Paragraph($"Дата формирования сертификата: {DateTime.Now:dd.MM.yyyy HH:mm}",
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC, BaseColor.GRAY));
                footer.Alignment = Element.ALIGN_RIGHT;
                document.Add(footer);

                document.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Записываем ошибку в лог
                System.Diagnostics.Debug.WriteLine($"Ошибка создания PDF: {ex.Message}");
                return false;
            }
        }

        private static void AddTableCell(PdfPTable table, string text, iTextSharp.text.Font font, bool isHeader = false)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 5;
            cell.BorderWidth = 1;

            if (isHeader)
            {
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            else
            {
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
            }

            table.AddCell(cell);
        }
    }
}