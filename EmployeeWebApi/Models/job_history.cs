namespace EmployeeWebApi.Models
{
    public class job_history
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DepartementId { get; set; }
        public string jobId { get; set; }
    }
}
