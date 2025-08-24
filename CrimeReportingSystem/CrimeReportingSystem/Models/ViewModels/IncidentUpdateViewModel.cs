using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.ViewModels
{
    public class IncidentUpdateViewModel
    {
        [Required]
        public int IncidentID { get; set; }

        [Required]
        public string Status { get; set; }
    }
}