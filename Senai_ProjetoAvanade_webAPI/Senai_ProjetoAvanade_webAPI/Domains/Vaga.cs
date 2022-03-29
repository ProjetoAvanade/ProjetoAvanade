using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdVaga { get; set; }
        public int? IdBicicletario { get; set; }
        public bool? StatusVaga { get; set; }

        public virtual Bicicletario IdBicicletarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
