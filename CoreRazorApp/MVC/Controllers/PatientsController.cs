using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PatientsController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Patient> plist = _context.patients.ToList();
            return View(plist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Allergies)
        {
            Patient p = new Patient();
            p.Allergies = Allergies;
            p.Name = Name;
            _context.patients.Add(p);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else {
            Patient p = _context.patients.Find(id);
            return View(p);
        }
        }
        [HttpPost]
        public IActionResult Edit(Patient p)
        {
            _context.patients.Update(p);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View(_context.patients.Find(id));
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteMethod(int id)
        {
            _context.patients.Remove(_context.patients.Find(id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
