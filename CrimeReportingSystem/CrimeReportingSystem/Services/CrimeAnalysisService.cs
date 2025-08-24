using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrimeReportingSystem.Models.Data;
using CrimeReportingSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;
using CrimeReportingSystem.Exceptions;

namespace CrimeReportingSystem.Services
{
    public class CrimeAnalysisService : ICrimeAnalysisService
    {
        private readonly ApplicationDbContext _context;

        public CrimeAnalysisService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateIncident(Incident incident)
        {
            try
            {
                _context.Incidents.Add(incident);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create incident", ex);
            }
        }

        public async Task<bool> UpdateIncidentStatus(int incidentId, string status)
        {
            try
            {
                var incident = await _context.Incidents.FindAsync(incidentId);
                if (incident == null)
                    throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found");

                incident.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update incident status", ex);
            }
        }

        public async Task<List<Incident>> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _context.Incidents
                    .Include(i => i.Victim)
                    .Include(i => i.Suspect)
                    .Include(i => i.Agency)
                    .Where(i => i.IncidentDate >= startDate && i.IncidentDate <= endDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve incidents in date range", ex);
            }
        }

        public async Task<List<Incident>> SearchIncidents(string incidentType)
        {
            try
            {
                return await _context.Incidents
                    .Include(i => i.Victim)
                    .Include(i => i.Suspect)
                    .Include(i => i.Agency)
                    .Where(i => i.IncidentType == incidentType)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to search incidents", ex);
            }
        }

        public async Task<Report> GenerateIncidentReport(int incidentId)
        {
            try
            {
                var incident = await _context.Incidents
                    .Include(i => i.Victim)
                    .Include(i => i.Suspect)
                    .Include(i => i.Agency)
                    .Include(i => i.EvidenceList)
                    .FirstOrDefaultAsync(i => i.IncidentID == incidentId);

                if (incident == null)
                    throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found");

                var report = new Report
                {
                    IncidentID = incidentId,
                    ReportingOfficerID = 1, // Default officer ID, should be replaced with actual user
                    ReportDate = DateTime.Now,
                    ReportDetails = $"Report for incident {incidentId} of type {incident.IncidentType}. " +
                                   $"Location: {incident.Latitude}, {incident.Longitude}. " +
                                   $"Status: {incident.Status}. " +
                                   $"Description: {incident.Description}",
                    Status = "Finalized"
                };

                _context.Reports.Add(report);
                await _context.SaveChangesAsync();

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to generate incident report", ex);
            }
        }

        public async Task<Case> CreateCase(string caseDescription, List<Incident> incidents)
        {
            try
            {
                var caseEntity = new Case
                {
                    CaseDescription = caseDescription,
                    Incidents = incidents
                };

                return await Task.FromResult(caseEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create case", ex);
            }
        }

        public async Task<Case> GetCaseDetails(int caseId)
        {
            try
            {
                return await Task.FromResult(new Case { CaseID = caseId });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get case details", ex);
            }
        }

        public async Task<bool> UpdateCaseDetails(Case caseDetails)
        {
            try
            {
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update case details", ex);
            }
        }

        public async Task<List<Case>> GetAllCases()
        {
            try
            {
                return await Task.FromResult(new List<Case>());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all cases", ex);
            }
        }
    }
}