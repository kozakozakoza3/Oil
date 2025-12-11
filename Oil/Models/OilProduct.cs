using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Oil.Models
{
    public class OilProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public string Application { get; set; }
        public string DangerClass { get; set; }
        public string Fraction { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public OilProduct() { }
        public OilProduct(int id, string name, string mark, string application,
                         string dangerClass, string fraction, DateTime manufactureDate,
                         DateTime expirationDate)
        {
            Id = id;
            Name = name;
            Mark = mark;
            Application = application;
            DangerClass = dangerClass;
            Fraction = fraction;
            ManufactureDate = manufactureDate;
            ExpirationDate = expirationDate;
        }
    }
}