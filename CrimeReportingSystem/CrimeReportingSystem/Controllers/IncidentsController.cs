using CrimeReportingSystem.Exceptions;
using CrimeReportingSystem.Models.Data;
using CrimeReportingSystem.Models.Entity;
using CrimeReportingSystem.Models.ViewModels;
using CrimeReportingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeReportingSystem.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly ICrimeAnalysisService _crimeAnalysisService;
        private readonly ApplicationDbContext _context;

        public IncidentsController(ICrimeAnalysisService crimeAnalysisService, ApplicationDbContext context)
        {
            _crimeAnalysisService = crimeAnalysisService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Victims = _context.Victims.ToList();
            ViewBag.Suspects = _context.Suspects.ToList();
            ViewBag.Agencies = _context.LawEnforcementAgencies.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncidentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int victimId = model.VictimID ?? 0;
                    int suspectId = model.SuspectID ?? 0;

                    // Create new victim if requested
                    if (model.CreateNewVictim && !string.IsNullOrEmpty(model.NewVictimFirstName))
                    {
                        var newVictim = new Victim
                        {
                            FirstName = model.NewVictimFirstName,
                            LastName = model.NewVictimLastName,
                            DateOfBirth = model.NewVictimDateOfBirth ?? DateTime.Now.AddYears(-30),
                            Gender = model.NewVictimGender,
                            Address = model.NewVictimAddress,
                            PhoneNumber = model.NewVictimPhoneNumber
                        };

                        _context.Victims.Add(newVictim);
                        await _context.SaveChangesAsync();
                        victimId = newVictim.VictimID;
                    }

                    // Create new suspect if requested
                    if (model.CreateNewSuspect && !string.IsNullOrEmpty(model.NewSuspectFirstName))
                    {
                        var newSuspect = new Suspect
                        {
                            FirstName = model.NewSuspectFirstName,
                            LastName = model.NewSuspectLastName,
                            DateOfBirth = model.NewSuspectDateOfBirth ?? DateTime.Now.AddYears(-30),
                            Gender = model.NewSuspectGender,
                            Address = model.NewSuspectAddress,
                            PhoneNumber = model.NewSuspectPhoneNumber
                        };

                        _context.Suspects.Add(newSuspect);
                        await _context.SaveChangesAsync();
                        suspectId = newSuspect.SuspectID;
                    }

                    // Validate that we have valid IDs
                    if (victimId == 0)
                    {
                        ModelState.AddModelError("", "Please select or create a victim");
                        RepopulateViewBags();
                        return View(model);
                    }

                    if (suspectId == 0)
                    {
                        ModelState.AddModelError("", "Please select or create a suspect");
                        RepopulateViewBags();
                        return View(model);
                    }

                    var incident = new Incident
                    {
                        IncidentType = model.IncidentType,
                        IncidentDate = model.IncidentDate,
                        Latitude = model.Latitude,
                        Longitude = model.Longitude,
                        Description = model.Description,
                        Status = model.Status,
                        VictimID = victimId,
                        SuspectID = suspectId,
                        AgencyID = model.AgencyID
                    };

                    var result = await _crimeAnalysisService.CreateIncident(incident);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Failed to create incident");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating incident: {ex.Message}");
                }
            }

            RepopulateViewBags();
            return View(model);
        }

        private void RepopulateViewBags()
        {
            ViewBag.Victims = _context.Victims.ToList();
            ViewBag.Suspects = _context.Suspects.ToList();
            ViewBag.Agencies = _context.LawEnforcementAgencies.ToList();
        }

        public IActionResult Edit(int id)
        {
            var model = new IncidentUpdateViewModel { IncidentID = id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IncidentUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _crimeAnalysisService.UpdateIncidentStatus(model.IncidentID, model.Status);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Failed to update incident status");
                }
                catch (IncidentNumberNotFoundException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating incident: {ex.Message}");
                }
            }
            return View(model);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(IncidentSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.StartDate.HasValue && model.EndDate.HasValue)
                    {
                        var incidents = await _crimeAnalysisService.GetIncidentsInDateRange(model.StartDate.Value, model.EndDate.Value);
                        return View("SearchResults", incidents);
                    }
                    else if (!string.IsNullOrEmpty(model.IncidentType))
                    {
                        var incidents = await _crimeAnalysisService.SearchIncidents(model.IncidentType);
                        return View("SearchResults", incidents);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error searching incidents: {ex.Message}");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var report = await _crimeAnalysisService.GenerateIncidentReport(id);
                return View(report);
            }
            catch (IncidentNumberNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating report: {ex.Message}");
            }
        }
    }
}