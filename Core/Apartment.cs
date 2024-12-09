using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Apartment
    {

        public int ApartmentId { get; set; }

        public string Address { get; set; }

        public string Status { get; set; } = "Ikke Fuldført";

        public Tenant Tenant { get; set; }

        public List<Availability> Availability { get; set; }
    }
}
