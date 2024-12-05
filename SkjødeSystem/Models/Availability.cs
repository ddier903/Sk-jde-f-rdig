namespace SkjødeSystem.Models
{
    public class Availability
    {
        public int ApartmentID { get; set; } // Identifier for the apartment
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}