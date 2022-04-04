using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    public interface IReservaRepository
    {
        /// <summary>
        /// Método para criar uma nova reserva de uma vaga
        /// </summary>
        /// <param name="novareserva">Nova reserva a ser realizada</param>
        void Cadastrar(Reserva novareserva);

        /// <summary>
        /// Metodo responsavel pela atualização de algumas informacoes de um reserva
        /// </summary>
        /// <param name="id">Id da reserva para ser atualizada</param>
        /// <param name="ReservaAtualizada">Novas informacoes da reserva</param>
        void Atualizar(int id, reservaViewModel ReservaAtualizada);

        /// <summary>
        /// Metodo responsavel popr listar as reservas do usuario logado
        /// </summary>
        /// <param name="id">Id do usuario logado</param>
        /// <returns>Uma lista de reservas</returns>
        List<Reserva> Listar_Minhas(int id);
    }
}
