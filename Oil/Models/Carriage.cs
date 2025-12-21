using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oil.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public string VinNumber { get; set; }
        public string Type { get; set; }
        public string LoadCapacity { get; set; }
        public string TrainName { get; set; }
        public int TrainId { get; set; }

        public Carriage(int id, string vinNumber, string type,
                       string loadCapacity, string trainName, int trainId)
        {
            Id = id;
            VinNumber = vinNumber;
            Type = type;
            LoadCapacity = loadCapacity;
            TrainName = trainName;
            TrainId = trainId;
        }
    }
}
