using System;

namespace Oil.Models
{
    public class Route
    {
        public int Route_id { get; set; }
        public string Route_status { get; set; }
        public DateTime Date_time_sending { get; set; }
        public DateTime Date_time_arrival { get; set; }
    }
}