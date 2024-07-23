using MedicalSystem.Data;
using MedicalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace MedicalSystem.Controllers
{
    public class DoctorsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            var result = _context.doctors.Include(x =>x.medicalSpecialities).OrderBy(x => x.fullName)
                .ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            ViewBag.Specialities = _context.specialities.OrderBy(x => x.specName).ToList();
          

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor model)
        {
            UploadImage(model);

            if (ModelState.IsValid)
            {
                _context.doctors.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            // ViewBag.Specialities = _context.specialities.OrderBy(x => x.specName).ToList();


            return View();
        }

        private void UploadImage(Doctor model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                //upload image
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.imageUser = imageName;
            }
            else if (model.imageUser == null && model.doctorId == null)
            {
                model.imageUser = "DefaultImage.jpg";
            }
            else
            {
                //not upload image
                model.imageUser = model.imageUser;
            }
        }

        public IActionResult Edit(int? Id)
        {
            ViewBag.Specialities = _context.specialities.OrderBy(x => x.specName).ToList();

            var Result = _context.doctors.Find(Id);
            return View("Create",Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor model)
        {
            UploadImage(model);

            if (ModelState.IsValid)
            {
                _context.doctors.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
             ViewBag.Specialities = _context.specialities.OrderBy(x => x.specName).ToList();
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            ViewBag.Specialities = _context.specialities.OrderBy(x => x.specName).ToList();

            var Result = _context.doctors.Find(Id);
            if (Result != null)
            {
                _context.doctors.Remove(Result);
                _context.SaveChanges();
                    }

            return RedirectToAction("Index");
        }
    }
}
