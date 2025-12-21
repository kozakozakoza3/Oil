using System;

namespace Oil.Models
{
    public class InvoicePrintData
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string CounterpartyName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePosition { get; set; }
        public string TrainName { get; set; }
        public string StartingPoint { get; set; }
        public string Destination { get; set; }
        public string Distance { get; set; }
        public string ProductName { get; set; }
        public string ProductMark { get; set; }
        public string LotSize { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? SendingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string RouteStatus { get; set; }
        public DateTime PrintDateTime { get; set; }
    }
}