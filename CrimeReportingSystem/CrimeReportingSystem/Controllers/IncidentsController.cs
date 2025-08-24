using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrimeReportingSystem.Services;
using CrimeReportingSystem.Models.ViewModels;
using CrimeReportingSystem.Models.Entity;
using CrimeReportingSystem.Exceptions;

namespace CrimeReportingSystem.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly ICrimeAnalysisService _crimeAnalysisService;

        public IncidentsController(ICrimeAnalysisService crimeAnalysisService)
        {
            _crimeAnalysisService = crimeAnalysisService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncidentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var incident = new Incident
                {
                    IncidentType = model.IncidentType,
                    IncidentDate = model.IncidentDate,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Description = model.Description,
                    Status = model.Status,
                    VictimID = model.VictimID,
                    SuspectID = model.SuspectID,
                    AgencyID = model.AgencyID
                };

                var result = await _crimeAnalysisService.CreateIncident(incident);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to create incident");
            }
            return View(model);
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
        }
    }
}