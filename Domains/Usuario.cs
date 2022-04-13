using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_ProjetoAvanade_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public int? Pontos { get; set; }
        public decimal? Saldo { get; set; }
        public string Imagem { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
