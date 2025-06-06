using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using codex.Models;
using Microsoft.AspNetCore.Mvc;
using codex.Data;

namespace codex.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TipoDispositivo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TipoUso { get; set; }

        public List<Computadora> Computadoras { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Computadoras.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Search))
            {
                query = query.Where(c =>
                    c.Marca.Contains(Search) ||
                    c.Modelo.Contains(Search) ||
                    c.Procesador.Contains(Search) ||
                    c.TarjetaGrafica.Contains(Search));
            }

            if (!string.IsNullOrWhiteSpace(TipoDispositivo))
            {
                if (Enum.TryParse<TipoDispositivo>(TipoDispositivo, out var tipo))
                    query = query.Where(c => c.TipoDispositivo == tipo);
            }

            if (!string.IsNullOrWhiteSpace(TipoUso))
            {
                if (Enum.TryParse<TipoUso>(TipoUso, out var uso))
                    query = query.Where(c => c.TipoRecomendado == uso);
            }

            Computadoras = await query.ToListAsync();
        }
    }
}
