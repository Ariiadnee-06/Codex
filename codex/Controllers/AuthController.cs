using Codex.Data;
using Codex.Models;
using Microsoft.AspNetCore.Mvc;

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

            // Retornar datos del usuario para login automático
            return Ok(new
            {
                mensaje = "Usuario registrado exitosamente.",
                usuario = new
                {
                    usuario.ID_Usuario,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Correo,
                    usuario.Rol
                }
            });
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            Console.WriteLine($"📥 Recibido Correo: {login?.Correo}");
            Console.WriteLine($"📥 Recibido Contraseña: {login?.ContraseñaHash}");

            if (login == null || string.IsNullOrWhiteSpace(login.Correo) || string.IsNullOrWhiteSpace(login.ContraseñaHash))
                return BadRequest(new { mensaje = "Faltan datos en la solicitud." });

            var dbUser = _context.Usuarios.FirstOrDefault(u => u.Correo == login.Correo);
            if (dbUser == null)
                return Unauthorized(new { mensaje = "Correo no encontrado." });

            bool valido = BCrypt.Net.BCrypt.Verify(login.ContraseñaHash, dbUser.ContraseñaHash);
            if (!valido)
                return Unauthorized(new { mensaje = "Contraseña incorrecta." });

            return Ok(new
            {
                mensaje = "Login exitoso",
                usuario = new
                {
                    dbUser.ID_Usuario,
                    dbUser.Nombre,
                    dbUser.Apellido,
                    dbUser.Correo,
                    dbUser.Rol
                }
            });
        }




    }
}
