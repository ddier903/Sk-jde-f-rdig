namespace SkjødeSystem.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Image { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string Comment { get; set; } = String.Empty;
        public int SubcontractorID { get; set; }
        public int AdminId { get; set; }
        public string ToDoPDF { get; set; } = String.Empty;

    }


}
