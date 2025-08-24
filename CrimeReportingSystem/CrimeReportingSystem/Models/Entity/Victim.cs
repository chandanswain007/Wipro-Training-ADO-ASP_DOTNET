using System;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class Victim
    {
        [Key]
        public int VictimID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}