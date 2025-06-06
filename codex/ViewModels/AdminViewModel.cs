using System.Collections.Generic;
using codex.Models;

namespace codex.ViewModels
{
    public class AdminViewModel
    {
        public Computadora ComputadoraActual { get; set; }
        public IEnumerable<Computadora> Computadoras { get; set; }
    }
}
