using codex.Data;
using codex.Models;
using codex.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Create(AdminViewModel model)
        {
            Console.WriteLine("🟡 ENTRÓ AL MÉTODO CREATE");

            if (ModelState.IsValid)
            {
                Console.WriteLine("✅ ModelState es válido");

                _context.Computadoras.Add(model.ComputadoraActual);
                _context.SaveChanges();

                Console.WriteLine("💾 Computadora guardada exitosamente");
                return RedirectToAction("Admin");
            }

            Console.WriteLine("❌ ModelState inválido");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("❗ Error: " + error.ErrorMessage);
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
