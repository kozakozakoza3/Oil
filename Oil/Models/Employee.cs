using System;

namespace Oil.Models
{
    // Модель данных для сотрудника
    public class Employee
    {
        public int Employee_id { get; set; }
        public string Last_name { get; set; }
        public string Name { get; set; }
        public string Middle_name { get; set; }
        public int Sex_id { get; set; }
        public int Education_level_id { get; set; }
        public int Department_id { get; set; }
        public int Post_id { get; set; }
        public int Qualification_id { get; set; }
        public string Passport_series { get; set; }
        public string Passport_number { get; set; }
        public DateTime Passport_issue_date { get; set; }
        public string Who_issued_passport { get; set; }
        public string Subdivision_code { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Residential_address { get; set; }
        public string Registration_address { get; set; }
        public string Sex_name { get; set; }
        public string Education_level { get; set; }
        public string Department_name { get; set; }
        public string Post_name { get; set; }
        public string Qualification_name { get; set; }
        public string Educational_institution { get; set; }
    }
}