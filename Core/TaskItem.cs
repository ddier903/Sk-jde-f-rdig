using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TaskItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string TaskId { get; set; }
        [Required]
        public string TaskName { get; set; } = string.Empty;
        public string? Image { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public DateTime? ActualEndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Comment { get; set; } = string.Empty;
        public string? ToDoPDF { get; set; }
        [Required]
        public Apartment AssignedApartment { get; set; }
        [Required]
        public Subcontractor AssignedTo { get; set; }

    }
}
