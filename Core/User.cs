﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    [BsonDiscriminator(RootClass = true)] 
    [BsonKnownTypes(typeof(Subcontractor))] 
    public class User 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
