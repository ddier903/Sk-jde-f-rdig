namespace SkjødeSystem.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } = "Ikke Fuldført";

        public Tenant tenant { get; set; }
        public List<Availability> Availability { get; set; }
    }
}
