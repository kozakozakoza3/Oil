using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oil.Models
{
    public class Locomotive
    {
        public int Id { get; set; }
        public string StateNumber { get; set; }
        public decimal TractionForce { get; set; }
        public int StructuralSpeed { get; set; }
        public int EnginePower { get; set; }
        public string TrainName { get; set; }
        public int TrainId { get; set; }

        public Locomotive(int id, string stateNumber, decimal tractionForce,
                         int structuralSpeed, int enginePower, string trainName, int trainId)
        {
            Id = id;
            StateNumber = stateNumber;
            TractionForce = tractionForce;
            StructuralSpeed = structuralSpeed;
            EnginePower = enginePower;
            TrainName = trainName;
            TrainId = trainId;
        }
    }
}
