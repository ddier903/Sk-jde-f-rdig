using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    [BsonDiscriminator(RootClass = true)] 
    [BsonKnownTypes(typeof(Subcontractor))]
    [BsonKnownTypes(typeof(Admin))]
    [BsonKnownTypes(typeof(Tenant))]
    public class User 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; } 
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
