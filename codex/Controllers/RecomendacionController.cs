using codex.Data;
using codex.Models;
using codex.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace codex.Controllers
{
    public class RecomendacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecomendacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Formulario()
        {
            return View(new FormularioRecomendacionViewModel());
        }

        [HttpPost]
        public IActionResult Formulario(FormularioRecomendacionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // ESTO OBTENDRÁ TODAS las computadoras que estén dentro del presupuesto
            var computadorasCandidatas = _context.Computadoras
                .Where(c => c.Precio <= model.Presupuesto)
                .ToList();

            // Filtro 1: portabilidad
            if (model.NecesitaPortabilidad)
                computadorasCandidatas = computadorasCandidatas
                    .Where(c => c.TipoDispositivo == TipoDispositivo.Portatil).ToList();

            // Filtro 2: gráficos
            if (model.UsaProgramasGraficos)
                computadorasCandidatas = computadorasCandidatas
                    .Where(c => !string.IsNullOrEmpty(c.TarjetaGrafica) && c.TarjetaGrafica != "Integrada").ToList();

            // Filtro 3: multitarea
            if (model.RealizaMultitareaPesada)
                computadorasCandidatas = computadorasCandidatas
                    .Where(c => c.MemoriaRam.Contains("16") || c.MemoriaRam.Contains("32")).ToList();

            // Filtro 4: tipo de uso específico
            computadorasCandidatas = computadorasCandidatas
                .Where(c => CumpleRequisitosMinimos(model.UsoPrincipal.Value, c))
                .ToList();

            // Filtro personalizado (si aplica)
            if (model.DeseaPersonalizar)
            {
                var marcaPreferida = Request.Form["MarcaPreferida"];
                var almacenamiento = Request.Form["TipoAlmacenamiento"];

                if (!string.IsNullOrEmpty(marcaPreferida))
                    computadorasCandidatas = computadorasCandidatas
                        .Where(c => c.Marca.Contains(marcaPreferida)).ToList();

                if (almacenamiento == "SSD")
                {
                    computadorasCandidatas = computadorasCandidatas
                        .Where(c =>
                            c.AlmacenamientoPrincipal.Contains("SSD") ||
                            (c.AlmacenamientoSecundario?.Contains("SSD") ?? false)
                        ).ToList();
                }
                else if (almacenamiento == "HDD")
                {
                    computadorasCandidatas = computadorasCandidatas
                        .Where(c =>
                            c.AlmacenamientoPrincipal.Contains("HDD") ||
                            (c.AlmacenamientoSecundario?.Contains("HDD") ?? false)
                        ).ToList();
                }
                else if (almacenamiento == "Ambos")
                {
                    computadorasCandidatas = computadorasCandidatas
                        .Where(c =>
                            c.AlmacenamientoPrincipal.Contains("SSD") &&
                            (c.AlmacenamientoSecundario?.Contains("HDD") ?? false)
                        ).ToList();
                }
            }


            var resultadosFinales = computadorasCandidatas
                .OrderBy(c => c.Precio)
                .Take(3)
                .ToList();

            return View("Resultado", resultadosFinales);
        }

        private bool CumpleRequisitosMinimos(TipoUso tipoUso, Computadora c)
        {
            string cpu = c.Procesador.ToLower();
            string gpu = c.TarjetaGrafica?.ToLower() ?? "";
            string ram = c.MemoriaRam.ToLower();
            string almPrincipal = c.AlmacenamientoPrincipal?.ToLower() ?? "";
            string almSecundario = c.AlmacenamientoSecundario?.ToLower() ?? "";

            bool tieneGPUdedicada = !c.TieneGPUIntegrada && !string.IsNullOrWhiteSpace(gpu);

            switch (tipoUso)
            {
                case TipoUso.Basico:
                    return ram.Contains("4") &&
                           (cpu.Contains("celeron") || cpu.Contains("i3") || cpu.Contains("pentium") || cpu.Contains("ryzen 3"));

                case TipoUso.Estudiante:
                    return ram.Contains("4") &&
                           (cpu.Contains("i3") || cpu.Contains("ryzen 3"));

                case TipoUso.Programador:
                    return ram.Contains("8") &&
                           (cpu.Contains("i5") || cpu.Contains("ryzen 5")) &&
                           almPrincipal.Contains("ssd");

                case TipoUso.Disenador:
                    return ram.Contains("8") &&
                           tieneGPUdedicada &&
                           almPrincipal.Contains("ssd");

                case TipoUso.EditorVideo:
                    return ram.Contains("16") &&
                           tieneGPUdedicada &&
                           (cpu.Contains("i7") || cpu.Contains("ryzen 7")) &&
                           almPrincipal.Contains("ssd");

                case TipoUso.TecnicoAvanzado:
                    return ram.Contains("16") &&
                           tieneGPUdedicada &&
                           cpu.Contains("i7") &&
                           almPrincipal.Contains("ssd");

                case TipoUso.Gamer:
                    return ram.Contains("16") &&
                           (gpu.Contains("gtx") || gpu.Contains("rtx") || gpu.Contains("rx")) &&
                           (cpu.Contains("i5") || cpu.Contains("i7") || cpu.Contains("ryzen")) &&
                           almPrincipal.Contains("ssd");

                default:
                    return false;
            }
        }


    }
}
