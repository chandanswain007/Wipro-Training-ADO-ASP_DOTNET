using System;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.ViewModels
{
    public class IncidentCreateViewModel
    {
        [Required]
        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }

        [Required]
        [Display(Name = "Incident Date")]
        public DateTime IncidentDate { get; set; }

        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }

        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        // Existing victim/suspect selection
        [Display(Name = "Select Existing Victim")]
        public int? VictimID { get; set; }

        [Display(Name = "Select Existing Suspect")]
        public int? SuspectID { get; set; }

        [Display(Name = "Agency")]
        public int AgencyID { get; set; }

        // New victim creation fields
        [Display(Name = "Or Create New Victim")]
        public bool CreateNewVictim { get; set; }

        [Display(Name = "Victim First Name")]
        public string NewVictimFirstName { get; set; }

        [Display(Name = "Victim Last Name")]
        public string NewVictimLastName { get; set; }

        [Display(Name = "Victim Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? NewVictimDateOfBirth { get; set; }

        [Display(Name = "Victim Gender")]
        public string NewVictimGender { get; set; }

        [Display(Name = "Victim Address")]
        public string NewVictimAddress { get; set; }

        [Display(Name = "Victim Phone Number")]
        public string NewVictimPhoneNumber { get; set; }

        // New suspect creation fields
        [Display(Name = "Or Create New Suspect")]
        public bool CreateNewSuspect { get; set; }

        [Display(Name = "Suspect First Name")]
        public string NewSuspectFirstName { get; set; }

        [Display(Name = "Suspect Last Name")]
        public string NewSuspectLastName { get; set; }

        [Display(Name = "Suspect Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? NewSuspectDateOfBirth { get; set; }

        [Display(Name = "Suspect Gender")]
        public string NewSuspectGender { get; set; }

        [Display(Name = "Suspect Address")]
        public string NewSuspectAddress { get; set; }

        [Display(Name = "Suspect Phone Number")]
        public string NewSuspectPhoneNumber { get; set; }
    }
}