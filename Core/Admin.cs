
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Admin : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
