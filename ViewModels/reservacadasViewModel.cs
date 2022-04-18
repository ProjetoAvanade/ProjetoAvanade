using System;
using System.ComponentModel.DataAnnotations;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class reservacadasViewModel
    {

        [Required]
        public int? IdVaga { get; set; }
    }
}
