using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrimeReportingSystem.Models.Entity;

namespace CrimeReportingSystem.Services
{
    public interface ICrimeAnalysisService
    {
        Task<bool> CreateIncident(Incident incident);
        Task<bool> UpdateIncidentStatus(int incidentId, string status);
        Task<List<Incident>> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        Task<List<Incident>> SearchIncidents(string incidentType);
        Task<Report> GenerateIncidentReport(int incidentId);
        Task<Case> CreateCase(string caseDescription, List<Incident> incidents);
        Task<Case> GetCaseDetails(int caseId);
        Task<bool> UpdateCaseDetails(Case caseDetails);
        Task<List<Case>> GetAllCases();
    }

    public class Case
    {
        public int CaseID { get; set; }
        public string CaseDescription { get; set; }
        public List<Incident> Incidents { get; set; } = new List<Incident>();
    }
}