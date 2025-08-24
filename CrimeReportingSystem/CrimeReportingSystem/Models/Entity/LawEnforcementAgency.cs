using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class LawEnforcementAgency
    {
        [Key]
        public int AgencyID { get; set; }

        [Required]
        [StringLength(100)]
        public string AgencyName { get; set; }

        [StringLength(100)]
        public string Jurisdiction { get; set; }

        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public List<Officer> Officers { get; set; } = new List<Officer>();
    }
}