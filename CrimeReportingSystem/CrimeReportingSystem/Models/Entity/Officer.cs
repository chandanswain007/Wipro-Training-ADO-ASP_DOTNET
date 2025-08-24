using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class Officer
    {
        [Key]
        public int OfficerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string BadgeNumber { get; set; }

        [StringLength(50)]
        public string Rank { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int AgencyID { get; set; }
        public LawEnforcementAgency Agency { get; set; }
    }
}