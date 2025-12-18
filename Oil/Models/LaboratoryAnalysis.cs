using System;

namespace Oil.Models
{
    public class LaboratoryAnalysis
    {
        // Основные поля из таблицы Laboratory_analysis
        public int LaboratoryAnalysisId { get; set; }
        // Для удобства - связанные данные
        public string ProductName { get; set; }
        public string AnalystName { get; set; }


        // Простой конструктор для удобства
        public LaboratoryAnalysis(int id, string productName, string analystName)
        {
            LaboratoryAnalysisId = id;
            ProductName = productName;
            AnalystName = analystName;
        }
    }
}