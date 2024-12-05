using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace SkjødeSystem.Models
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly? EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string Comment { get; set; } = string.Empty;
        public string SubcontractorID { get; set; }
        public int AdminId { get; set; }
        public IBrowserFile? ToDoPDF { get; set; }

    }


}
