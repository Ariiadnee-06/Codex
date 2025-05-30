using System.ComponentModel.DataAnnotations;

namespace codex.Models
{
    public class Pregunta
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Texto { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
