using System;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.ViewModels
{
    public class IncidentSearchViewModel
    {
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Incident Type")]
        public string IncidentType { get; set; }
    }
}