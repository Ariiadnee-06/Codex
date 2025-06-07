using codex.Models;

namespace codex.ViewModels
{
    public class AdminViewModel
    {
        public Computadora ComputadoraActual { get; set; } = new Computadora();
        public IEnumerable<Computadora> Computadoras { get; set; } = new List<Computadora>();
    }
}
