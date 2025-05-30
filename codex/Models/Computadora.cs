using System.ComponentModel.DataAnnotations;

namespace codex.Models
{
    public class Computadora
    {
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public TipoDispositivo TipoDispositivo { get; set; }

        [Required]
        public string Procesador { get; set; }

        public string GeneracionCPU { get; set; }

        [Required]
        public string MemoriaRam { get; set; }

        public string TipoRam { get; set; }

        [Required]
        public string AlmacenamientoPrincipal { get; set; }

        // Nota de Lady: el ? despues del STRING significa que este campo es opcional
        public string? AlmacenamientoSecundario { get; set; }


        [Required]
        public string TarjetaGrafica { get; set; }

        public bool TieneGPUIntegrada { get; set; }

        public double PantallaPulgadas { get; set; }

        public int ResolucionVertical { get; set; }
        public int ResolucionHorizontal { get; set; }

        public string Puertos { get; set; }

        public string Conectividad { get; set; }

        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; }

        [Required]
        public TipoUso TipoRecomendado { get; set; }

        public string Descripcion { get; set; }
    }
}
