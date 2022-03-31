using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            Reservas = new HashSet<Reserva>();
        }

        [Key]
        public int IdVaga { get; set; }

        [Required]
        public int? IdBicicletario { get; set; }

        [Required]
        public bool? StatusVaga { get; set; }

        public virtual Bicicletario IdBicicletarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
