using Microsoft.AspNetCore.Mvc;
using CrimeReportingSystem.Exceptions;

namespace CrimeReportingSystem.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, something went wrong on the server";
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, an error occurred while processing your request";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}