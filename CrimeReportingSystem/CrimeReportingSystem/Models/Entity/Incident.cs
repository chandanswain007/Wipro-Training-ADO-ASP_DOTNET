using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class Incident
    {
        [Key]
        public int IncidentID { get; set; }

        [Required]
        [StringLength(50)]
        public string IncidentType { get; set; }

        [Required]
        public DateTime IncidentDate { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public int VictimID { get; set; }
        public Victim Victim { get; set; }

        public int SuspectID { get; set; }
        public Suspect Suspect { get; set; }

        public int AgencyID { get; set; }
        public LawEnforcementAgency Agency { get; set; }

        public List<Evidence> EvidenceList { get; set; } = new List<Evidence>();
        public List<Report> Reports { get; set; } = new List<Report>();
    }
}