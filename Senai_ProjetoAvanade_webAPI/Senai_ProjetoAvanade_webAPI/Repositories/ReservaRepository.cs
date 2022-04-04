using Microsoft.EntityFrameworkCore;
using Senai_ProjetoAvanade_webAPI.Contexts;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class ReservaRepository : IReservaRepository
    {

        private readonly AvanadeContext ctx;

        public ReservaRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        /// <summary>
        /// Metodo responsavel por atualizar uma reserva ja existente
        /// </summary>
        /// <param name="id">Id da reserva a ser atualizada</param>
        /// <param name="ReservaAtualizada">Novas informações</param>
        public void Atualizar(int id, reservaViewModel ReservaAtualizada)
        {
            Reserva reservaBuscada = ctx.Reservas.FirstOrDefault(c => c.IdReserva == id);

            if (reservaBuscada != null)
            {
                reservaBuscada.FechaTrava = ReservaAtualizada.FechaTrava;
                reservaBuscada.Preco = ReservaAtualizada.Preco;
                reservaBuscada.StatusPagamento = ReservaAtualizada.StatusPagamento;
            }

            ctx.Reservas.Update(reservaBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Reserva novareserva)
        {
            ctx.Reservas.Add(novareserva);

            ctx.SaveChanges();
        }

        public List<Reserva> Listar_Minhas(int id)
        {
            return ctx.Reservas.Include(c => c.IdVagaNavigation).Include(c => c.IdUsuarioNavigation)
                .Select(c => new Reserva() { 
                IdReserva = c.IdReserva,
                IdUsuario = c.IdUsuario,
                IdUsuarioNavigation = new Usuario()
                {
                    NomeUsuario = c.IdUsuarioNavigation.NomeUsuario,
                    Email = c.IdUsuarioNavigation.Email,
                    Cpf = c.IdUsuarioNavigation.Cpf
                },
                IdVagaNavigation = new Vaga()
                {
                    IdVaga = c.IdVagaNavigation.IdVaga,
                    IdBicicletarioNavigation = new Bicicletario()
                    {
                        Nome = c.IdVagaNavigation.IdBicicletarioNavigation.Nome,
                    }
                }
                })
                .Where(P => P.IdUsuario == id)
                .ToList();
        }
    }
}
