using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class Evidence
    {
        [Key]
        public int EvidenceID { get; set; }

        public string Description { get; set; }

        public string LocationFound { get; set; }

        public int IncidentID { get; set; }
        public Incident Incident { get; set; }
    }
}