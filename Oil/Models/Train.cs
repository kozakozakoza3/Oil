namespace Oil.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int LocomotiveCount { get; set; }
        public int CarriageCount { get; set; }

        public Train() { }

        public Train(int id, string name, string status, int locomotiveCount, int carriageCount)
        {
            Id = id;
            Name = name;
            Status = status;
            LocomotiveCount = locomotiveCount;
            CarriageCount = carriageCount;
        }
    }
}