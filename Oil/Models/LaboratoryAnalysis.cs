using System;

namespace Oil.Models
{
    public class LaboratoryAnalysis
    {
        // Основные поля из таблицы Laboratory_analysis
        public int LaboratoryAnalysisId { get; set; }
        public int OilProductId { get; set; }
        public int EmployeeId { get; set; }
        public decimal SampleVolume { get; set; }
        public string UnitOfMeasureVolume { get; set; }
        public double OilProductDensity { get; set; }
        public string UnitOfMeasureDensity { get; set; }
        public decimal OilProductSulfurContent { get; set; }
        public string UnitOfMeasureSulfur { get; set; }
        public double? OilProductWaterContent { get; set; }
        public string UnitOfMeasureWater { get; set; }
        public double OilProductViscosity { get; set; }
        public string UnitOfMeasureViscosity { get; set; }
        public int OilProductFlashPoint { get; set; }
        public string UnitOfMeasureFlash { get; set; }
        public DateTime DateTimeAnalysis { get; set; }

        // Для удобства - связанные данные
        public string ProductName { get; set; }
        public string AnalystName { get; set; }

        public LaboratoryAnalysis() { }

        // Простой конструктор для удобства
        public LaboratoryAnalysis(int id, string productName, string analystName)
        {
            LaboratoryAnalysisId = id;
            ProductName = productName;
            AnalystName = analystName;
        }
    }
}