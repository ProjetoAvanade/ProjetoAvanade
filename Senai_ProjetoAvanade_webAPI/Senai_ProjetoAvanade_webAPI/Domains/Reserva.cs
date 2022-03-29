using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVaga { get; set; }
        public DateTime? AbreTrava { get; set; }
        public DateTime? FechaTrava { get; set; }
        public decimal? Preco { get; set; }
        public bool? StatusPagamento { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
