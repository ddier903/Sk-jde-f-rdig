using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TaskItem
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId TaskId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Navnet er for langt")]
        public string TaskName { get; set; } = string.Empty;
        public string[]? Image { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Comment { get; set; } = string.Empty;
        public string[]? ToDoPDF { get; set; }
        public Apartment Apartment { get; set; }
        public Subcontractor AssignedTo { get; set; }
        public Admin CreatedBy { get; set; }

    }


}
