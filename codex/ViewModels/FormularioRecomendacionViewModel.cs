using codex.Models;
using System.ComponentModel.DataAnnotations;

namespace codex.ViewModels
{
    public class FormularioRecomendacionViewModel
    {
        [Required]
        public TipoUso? UsoPrincipal { get; set; }

        [Required]
        public bool NecesitaPortabilidad { get; set; }

        [Required]
        public bool RealizaMultitareaPesada { get; set; }

        // De Lady: Pongo este campo para que el usuario pueda indicar si usa programas gráficos pesados, como edición de video o diseño gráfico.
        [Required]
        public bool UsaProgramasGraficos { get; set; }

        // De Lady: Pongo este campo para que el usuario pueda ingresar su presupuesto y así poder filtrar las recomendaciones.
        [Required]
        [Range(100000, 99000000, ErrorMessage = "El presupuesto debe estar entre $100.000 y $99.000.000 COP.")]
        public decimal Presupuesto { get; set; }



        /// De Lady: Pongo este campo para que el usuario pueda personalizar su recomendación, si así lo desea.
        [Required]
        public bool DeseaPersonalizar { get; set; }

    }
}
