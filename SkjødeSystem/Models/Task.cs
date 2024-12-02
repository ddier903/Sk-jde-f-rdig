namespace SkjødeSystem.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int SubcontractorID { get; set; }
        public int AdminId { get; set; }
        public string ToDoPDF { get; set; }

    }
}
