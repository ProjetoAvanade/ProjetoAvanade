using System;
using System.ComponentModel.DataAnnotations;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class bicicletarioViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public int? Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public TimeSpan? HorarioAberto { get; set; }

        [Required]
        public TimeSpan? HorarioFechado { get; set; }
    }
}
