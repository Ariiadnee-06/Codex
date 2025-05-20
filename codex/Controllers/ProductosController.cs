using Codex.Data;
using Codex.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly CodexDbContext _context;

        public ProductosController(CodexDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }
    }
}
