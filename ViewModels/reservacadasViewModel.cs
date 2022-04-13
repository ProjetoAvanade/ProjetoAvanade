using System;
using System.ComponentModel.DataAnnotations;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class reservacadasViewModel
    {
        [Required]
        public int? IdUsuario { get; set; }

        [Required]
        public int? IdVaga { get; set; }

        [Required]
        public DateTime? AbreTrava { get; set; }
    }
}
