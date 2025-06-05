using Microsoft.AspNetCore.Mvc;
using codex.Data;
using codex.Models;

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
            var computadoras = _context.Computadoras.ToList();
            return View(computadoras);
        }

        [HttpPost]
        public IActionResult Create(Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                _context.Computadoras.Add(computadora);
                _context.SaveChanges();
            }
            return RedirectToAction("Crud");
        }

        [HttpPost]
        public IActionResult Update(Computadora computadora)
        {
            if (ModelState.IsValid)
            {
                _context.Computadoras.Update(computadora);
                _context.SaveChanges();
            }
            return RedirectToAction("Crud");
        }

        public IActionResult Delete(int id)
        {
            var computadora = _context.Computadoras.Find(id);
            if (computadora != null)
            {
                _context.Computadoras.Remove(computadora);
                _context.SaveChanges();
            }
            return RedirectToAction("Crud");
        }
    }
}
