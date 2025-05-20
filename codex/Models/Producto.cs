// ✅ MODELO PRODUCTOS OPTIMIZADO PARA SISTEMA DE RECOMENDACIÓN
namespace Codex.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        // Relación: Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        // Relación: TipoProducto
        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; }

        // Relación: UsoRecomendado
        public int UsoRecomendadoId { get; set; }
        public UsoRecomendado UsoRecomendado { get; set; }

        public string Modelo { get; set; }

        public string Procesador { get; set; }

        public int RAM { get; set; } // En GB

        public int Almacenamiento { get; set; } // En GB

        public string TipoAlmacenamiento { get; set; } // SSD o HDD

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string ImagenUrl { get; set; }

        public string Descripcion { get; set; }

        public int AñoLanzamiento { get; set; }

        public bool EsDestacado { get; set; } = false;

        public string PalabrasClave { get; set; } // Para búsqueda rápida por keywords
    }


}