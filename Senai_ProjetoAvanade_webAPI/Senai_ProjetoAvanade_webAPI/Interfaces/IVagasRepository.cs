using Senai_ProjetoAvanade_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    interface IVagasRepository
    {

        /// <summary>
        /// Métodos de listar todas as vagas de um bicicletário especifico
        /// </summary>
        /// <param name="id">id do bicicletario</param>
        /// <returns>Uma lista de vagas sobre um bicicletario especifico</returns>
        List<Vaga> ListarTodas(int id);
    }
}
