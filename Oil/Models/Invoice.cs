namespace Oil.Models
{
    public class Invoice
    {
        public int Invoice_id { get; set; }
        public int Oil_product_lot_id { get; set; }
        public int Counterparty_id { get; set; }
        public int Employee_id { get; set; }
        public int Train_id { get; set; }
        public int Final_point_id { get; set; }
        public string Starting_point { get; set; }
        public decimal Distance { get; set; }
        public string Unit_of_measure { get; set; }
        public System.DateTime Date_time_compliation_invoice { get; set; }
        public string Counterparty_name { get; set; }
        public string Employee_name { get; set; }
        public string Train_name { get; set; }
        public string Destination { get; set; }
        public string Product_name { get; set; }
        public string Lot_size { get; set; }
        public string Route_status { get; set; }
    }
}