using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codex.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Texto { get; set; }

        [Required]
        public TipoUso TipoUsoAsociado { get; set; }

        public int PreguntaId { get; set; }

        [ForeignKey("PreguntaId")]
        public Pregunta Pregunta { get; set; }
    }
}
