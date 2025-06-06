using Microsoft.AspNetCore.Mvc;
using codex.Data;
using codex.Models;
using codex.ViewModels;

namespace codex.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            var model = new AdminViewModel
            {
                Computadoras = _context.Computadoras.ToList(),
                ComputadoraActual = new Computadora()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Computadoras.Add(model.ComputadoraActual);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }
            model.Computadoras = _context.Computadoras.ToList();
            return View("Admin", model);
        }

        [HttpPost]
        public IActionResult Edit(Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                _context.Computadoras.Update(computadora);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            }
            var model = new AdminViewModel
            {
                Computadoras = _context.Computadoras.ToList(),
                ComputadoraActual = computadora
            };
            return View("Admin", model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var compu = _context.Computadoras.Find(id);
            if (compu != null)
            {
                _context.Computadoras.Remove(compu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }


}
