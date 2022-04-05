using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Bicicletario
    {
        public Bicicletario()
        {
            Vagas = new HashSet<Vaga>();
        }
        [Key]
        public int IdBicicletario { get; set; }

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

        public virtual ICollection<Vaga> Vagas { get; set; }
    }
}
