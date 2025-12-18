namespace Oil.Models
{
    public class Counterparty
    {
        public int Counterparty_id { get; set; }
        public string Counterparty_type_name { get; set; }
        public string Organization_name { get; set; }
        public string OKFS_code { get; set; }
        public string OKFS_name { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string Statutory_address { get; set; }
        public string Physical_address { get; set; }
    }
}