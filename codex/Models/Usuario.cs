using System;

namespace Codex.Models
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string ContraseñaHash { get; set; }
        public string Rol { get; set; } = "cliente";
        public string Estado { get; set; } = "activo";
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
