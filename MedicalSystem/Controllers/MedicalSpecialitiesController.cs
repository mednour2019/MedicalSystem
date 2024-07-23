using MedicalSystem.Data;
using MedicalSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Controllers
{
   
    public class MedicalSpecialitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MedicalSpecialitiesController( ApplicationDbContext context)
        {
            this._context = context;

        }

        [Route("MedicalSpecialities")]
        [Route("MedicalSpecialities/Index")]
        [Route("MedicalSpecialities/Index/{id?}")]
        public IActionResult Index()
        {

            var Result = _context.specialities.ToList();
            return View(Result);
        }
        public IActionResult Create()
        {

            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicalSpecialities model)
        {
            if (ModelState.IsValid)
            {
                _context.specialities.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

                return View();
        }
        public IActionResult Edit(int?Id)
        {
            var Result = _context.specialities.Find(Id);

            return View("Create",Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MedicalSpecialities Model)
        {
            if (ModelState.IsValid)
            {
                _context.specialities.Update(Model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

                return View();
        }
        public IActionResult Delete(int? Id)
        {
            var Result = _context.specialities.Find(Id);
            if (Result != null)
            {
                _context.specialities.Remove(Result);
                _context.SaveChanges();
            }


                return RedirectToAction(nameof(Index));
        }
    }
}
