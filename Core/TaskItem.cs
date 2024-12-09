
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TaskItem
    {
        public int? TaskId { get; set; }
        [Required]
        public string TaskName { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string? Comment { get; set; } = string.Empty;
        public byte[]? ToDoPDF { get; set; }
        public Apartment Apartment { get; set; }
        public Subcontractor Subcontractor { get; set; }
        public Admin Admin { get; set; }

    }


}
