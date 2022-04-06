using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    public interface IVagasRepository
    {

        /// <summary>
        /// Métodos de listar todas as vagas de um bicicletário especifico
        /// </summary>
        /// <param name="id">id do bicicletario</param>
        /// <returns>Uma lista de vagas sobre um bicicletario especifico</returns>
        List<Vaga> ListarTodas(int id);

        /// <summary>
        /// Método para atualizar o status de uma vaga
        /// </summary>
        /// <param name="id">Id da vaga a ser atualizada</param>
        /// <param name="status">novo valor de status para a vaga</param>
        void Atualizar(int id, vagasViewModel status);
    }
}
