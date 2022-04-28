using Microsoft.EntityFrameworkCore;
using Senai_ProjetoAvanade_webAPI.Context;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
                reservaBuscada.FechaTrava = DateTime.Now;

                TimeSpan Diff_dates = Convert.ToDateTime(reservaBuscada.FechaTrava).Subtract(Convert.ToDateTime(reservaBuscada.AbreTrava));

                //double diferenca = Convert.ToDouble(Diff_dates);


                reservaBuscada.Preco = Convert.ToDecimal(Diff_dates.TotalMinutes * 0.0625);
                //reservaBuscada.Preco = ReservaAtualizada.Preco;
                reservaBuscada.StatusPagamento = ReservaAtualizada.StatusPagamento;
            }

            ctx.Reservas.Update(reservaBuscada);

            ctx.SaveChanges();
        }

        public Usuario AtualizarPontos(int id)
        {
            //List <Reserva> reservabuscada = ctx.Reservas.Where(i => i.IdUsuario == id).ToList();

            List <Reserva> reservabuscada = ctx.Reservas.Where(i => i.IdUsuario == id && i.StatusPagamento == true).ToList();
            reservabuscada.Reverse();



            Usuario teste = ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);

            
            decimal valor_pago = Convert.ToDecimal(reservabuscada[0].Preco);

            decimal novos_pontos = (valor_pago / 2);

            teste.Pontos = teste.Pontos + Convert.ToInt32(novos_pontos);

            ctx.Usuarios.Update(teste);

            ctx.SaveChanges();
                    
            return teste;
        }

        public void Cadastrar(reservacadasViewModel novareserva, int id)
        {

            Reserva reservacadastro = new Reserva();

            reservacadastro.IdUsuario = id;
            reservacadastro.IdVaga = novareserva.IdVaga;
            reservacadastro.AbreTrava = DateTime.Now;

            ctx.Reservas.Add(reservacadastro);

            ctx.SaveChanges();
        }

        public List<Reserva> Listar_Lucros()
        {
            List<Reserva> valores_pagos = ctx.Reservas.Select(c => new Reserva()
            {
                IdReserva = c.IdReserva,
                Preco = c.Preco,
                FechaTrava = c.FechaTrava
            }).ToList();

            return valores_pagos;
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
