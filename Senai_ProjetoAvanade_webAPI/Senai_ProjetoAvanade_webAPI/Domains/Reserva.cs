using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        public int? IdUsuario { get; set; }

        [Required]
        public int? IdVaga { get; set; }

        [Required]
        public DateTime? AbreTrava { get; set; }
        public DateTime? FechaTrava { get; set; }
        public decimal? Preco { get; set; }
        public bool? StatusPagamento { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
