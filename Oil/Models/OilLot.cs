using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Oil
{
    // 1. Модель данных для партии нефти
    public class OilLot
    {
        public int Id { get; set; }
        public string LotNumber { get; set; }
        public DateTime ExtractionDate { get; set; }
        public string Color { get; set; }
        public string Fraction { get; set; }
        public string Density { get; set; }
        public string Viscosity { get; set; }
        public string SulfurContent { get; set; }
        public string Oilfield { get; set; }
        public string Region { get; set; }

        public OilLot(int id, string lotNumber, DateTime extractionDate, string color,
                      string fraction, string density, string viscosity, string sulfurContent,
                      string oilfield, string region)
        {
            Id = id;
            LotNumber = lotNumber;
            ExtractionDate = extractionDate;
            Color = color;
            Fraction = fraction;
            Density = density;
            Viscosity = viscosity;
            SulfurContent = sulfurContent;
            Oilfield = oilfield;
            Region = region;
        }
    }
}