using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Subcontractor : User
    {
        public string SubcontractorName { get; set; }

    }
}
