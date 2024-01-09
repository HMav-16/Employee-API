using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int ManagerId { get; set; }
        public string LocationId { get; set; }
    }
}
