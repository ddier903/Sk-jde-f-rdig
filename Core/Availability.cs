﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Availability
    {
        public int AvailabilityID { get; set; }
        public DateTime Date { get; set; }
    }
}