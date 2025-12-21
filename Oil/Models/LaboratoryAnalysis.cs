using System;

namespace Oil.Models
{
    public class LaboratoryAnalysis
    {
        // Основные поля из таблицы Laboratory_analysis
        public int LaboratoryAnalysisId { get; set; }
        public string ProductName { get; set; }
        public string AnalystName { get; set; }
        public LaboratoryAnalysis(int id, string productName, string analystName)
        {
            LaboratoryAnalysisId = id;
            ProductName = productName;
            AnalystName = analystName;
        }
    }
}