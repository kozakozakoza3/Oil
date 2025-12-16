using System;

namespace Oil.Helpers
{
    public class CertificatePrintData
    {
        // Основные данные
        public int AnalysisId { get; set; }
        public string ProductName { get; set; }
        public string ProductMark { get; set; }
        public string AnalystName { get; set; }
        public string AnalystPosition { get; set; }

        // Параметры анализа
        public decimal SampleVolume { get; set; }
        public string UnitOfMeasureVolume { get; set; }
        public decimal Density { get; set; }
        public string UnitOfMeasureDensity { get; set; }
        public decimal SulfurContent { get; set; }
        public string UnitOfMeasureSulfur { get; set; }
        public decimal Viscosity { get; set; }
        public string UnitOfMeasureViscosity { get; set; }
        public int FlashPoint { get; set; }
        public string UnitOfMeasureFlash { get; set; }

        // Даты
        public DateTime AnalysisDateTime { get; set; }
        public DateTime CertificateDateTime { get; set; }
    }
}