using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oil.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int TankNumber { get; set; }
        public int TankCapacity { get; set; }
        public string TankMaterial { get; set; }
        public decimal CurrentVolume { get; set; }

        public Storage(int id, string productName, int tankNumber, int tankCapacity,
                      string tankMaterial, decimal currentVolume)
        {
            Id = id;
            ProductName = productName;
            TankNumber = tankNumber;
            TankCapacity = tankCapacity;
            TankMaterial = tankMaterial;
            CurrentVolume = currentVolume;
        }
    }
}
