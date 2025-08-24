using System;
using System.ComponentModel.DataAnnotations;

namespace CrimeReportingSystem.Models.Entity
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        public int IncidentID { get; set; }
        public Incident Incident { get; set; }

        public int ReportingOfficerID { get; set; }
        public Officer ReportingOfficer { get; set; }

        public DateTime ReportDate { get; set; }

        public string ReportDetails { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }
}