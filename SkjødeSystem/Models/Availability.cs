namespace SkjødeSystem.Models
{
    public class Availability
    {
        public DateTime AvailabilityDate { get; set; }
        public int ApartmentID { get; set; }
        public int AvailabilityID { get; set; }

        public TimeOnly Time {  get; set; }
    }
}
