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
        public IActionResult Editar(int id, Computadora nuevaCompu)
        {
            var compuExistente = _context.Computadoras.Find(id);

            if (compuExistente == null)
                return NotFound();

            if (
                compuExistente.Marca == nuevaCompu.Marca &&
                compuExistente.Modelo == nuevaCompu.Modelo &&
                compuExistente.Procesador == nuevaCompu.Procesador &&
                compuExistente.MemoriaRam == nuevaCompu.MemoriaRam &&
                compuExistente.AlmacenamientoPrincipal == nuevaCompu.AlmacenamientoPrincipal &&
                compuExistente.Precio == nuevaCompu.Precio
            )
            {
                TempData["Mensaje"] = "El componente no tiene elementos por editar.";
                return RedirectToAction("Admin"); 
            }

            compuExistente.Marca = nuevaCompu.Marca;
            compuExistente.Modelo = nuevaCompu.Modelo;
            compuExistente.Procesador = nuevaCompu.Procesador;
            compuExistente.MemoriaRam = nuevaCompu.MemoriaRam;
            compuExistente.AlmacenamientoPrincipal = nuevaCompu.AlmacenamientoPrincipal;
            compuExistente.Precio = nuevaCompu.Precio;

            _context.SaveChanges();

            TempData["Mensaje"] = "Componente editado correctamente.";
            return RedirectToAction("Admin");
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
