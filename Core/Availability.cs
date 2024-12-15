using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Availability
    {
        public int AvailabilityID { get; set; }

        [JsonPropertyName("date")]

        public DateTime Date { get; set; } 
        public TimeSpan? Time { get; set; }
    }
}