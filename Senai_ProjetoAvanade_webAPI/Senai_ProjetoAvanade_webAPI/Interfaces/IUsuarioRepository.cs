using Senai_ProjetoAvanade_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Metodo responsavel pelo login do usuario
        /// </summary>
        /// <param name="email">Email inserido pelo usuario para comparacao</param>
        /// <param name="senha">Senha inserida pelo usuario para comparção</param>
        /// <returns>Retorna um usuario caso os valores recebidos sejam semelhantes aos do banco de dados.</returns>
        Usuario Login(string email, string senha);
    }
}
