namespace SkjødeSystem.Models
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string Comment { get; set; } = string.Empty;
        public string SubcontractorID { get; set; }
        public int AdminId { get; set; }
        public string ToDoPDF { get; set; } = string.Empty;

    }


}
