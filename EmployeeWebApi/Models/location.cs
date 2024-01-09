using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class location
    {
        [Key]
        public string locationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }
    }
}
