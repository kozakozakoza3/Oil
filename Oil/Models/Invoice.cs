using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oil.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Counterparty { get; set; }
        public string ResponsibleEmployee { get; set; }
        public string TrainName { get; set; }
        public string StartingPoint { get; set; }
        public string FinalPoint { get; set; }
        public decimal Distance { get; set; }
        public decimal LotSize { get; set; }
        public DateTime CompilationDate { get; set; }
        public string RouteStatus { get; set; }

        public Invoice(int id, string productName, string counterparty,
                      string responsibleEmployee, string trainName, string startingPoint,
                      string finalPoint, decimal distance, decimal lotSize,
                      DateTime compilationDate, string routeStatus)
        {
            Id = id;
            ProductName = productName;
            Counterparty = counterparty;
            ResponsibleEmployee = responsibleEmployee;
            TrainName = trainName;
            StartingPoint = startingPoint;
            FinalPoint = finalPoint;
            Distance = distance;
            LotSize = lotSize;
            CompilationDate = compilationDate;
            RouteStatus = routeStatus;
        }
    }
}
