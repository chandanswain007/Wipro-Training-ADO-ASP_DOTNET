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

        [Display(Name = "Victim ID")]
        public int VictimID { get; set; }

        [Display(Name = "Suspect ID")]
        public int SuspectID { get; set; }

        [Display(Name = "Agency ID")]
        public int AgencyID { get; set; }
    }
}