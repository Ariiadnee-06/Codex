using Microsoft.AspNetCore.Mvc;
using Codex.Data;
using Codex.Models;

namespace Codex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly CodexDbContext _context;

        public AuthController(CodexDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Correo == usuario.Correo))
                return BadRequest(new { mensaje = "Este correo ya está registrado." });

            usuario.ContraseñaHash = BCrypt.Net.BCrypt.HashPassword(usuario.ContraseñaHash);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok(new { mensaje = "Usuario registrado exitosamente." });
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var dbUser = _context.Usuarios.FirstOrDefault(u => u.Correo == usuario.Correo);
            if (dbUser == null) return Unauthorized("Correo no encontrado.");

            bool valido = BCrypt.Net.BCrypt.Verify(usuario.ContraseñaHash, dbUser.ContraseñaHash);
            if (!valido) return Unauthorized("Contraseña incorrecta.");

            return Ok(new { mensaje = "Login exitoso", usuario = dbUser });
        }
    }
}
