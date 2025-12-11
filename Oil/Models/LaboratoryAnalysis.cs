using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Oil.Models
{
    public class LaboratoryAnalysis
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Analyst { get; set; }
        public double Density { get; set; }
        public double SulfurContent { get; set; }
        public double? WaterContent { get; set; }
        public double Viscosity { get; set; }
        public int FlashPoint { get; set; }
        public DateTime AnalysisDate { get; set; }

        public LaboratoryAnalysis() { }
        public LaboratoryAnalysis(int id, string productName, string analyst,
                             double density, double sulfurContent, double? waterContent,
                             double viscosity, int flashPoint, DateTime analysisDate)
        {
            Id = id;
            ProductName = productName;
            Analyst = analyst;
            Density = density;
            SulfurContent = sulfurContent;
            WaterContent = waterContent;
            Viscosity = viscosity;
            FlashPoint = flashPoint;
            AnalysisDate = analysisDate;
        }
    }
}