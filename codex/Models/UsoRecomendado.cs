namespace Codex.Models
{
    public class UsoRecomendado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
