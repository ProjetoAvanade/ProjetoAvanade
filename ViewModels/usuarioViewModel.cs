using System;
using System.ComponentModel.DataAnnotations;

namespace Senai_ProjetoAvanade_webAPI.ViewModels
{
    public class usuarioViewModel
    {
        [Required]
        public int? IdTipoUsuario { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Imagem { get; set; }
    }
}
