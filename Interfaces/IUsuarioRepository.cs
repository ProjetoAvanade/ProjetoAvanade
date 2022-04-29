using Microsoft.AspNetCore.Http;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Metodo responsavel pelo login do usuario
        /// </summary>
        /// <param name="email">Email inserido pelo usuario para comparacao</param>
        /// <param name="senha">Senha inserida pelo usuario para comparção</param>
        /// <returns>Retorna um usuario caso os valores recebidos sejam semelhantes aos do banco de dados.</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Método de cadastro de usuario
        /// </summary>
        /// <param name="usuarionovo">Novo objeto do tipo usuario para cadastro</param>
        void Cadastrar(usuarioViewModel usuarionovo);

        /// <summary>
        /// Metodo responsavel por buscar um ususario especifico pelo ID
        /// </summary>
        /// <param name="id">Id a ser buscado</param>
        /// <returns>Um usuario especifico</returns>
        Usuario BuscarId(int id);

        /// <summary>
        /// Metodo responsavel pela atulizacao de saldo na conta
        /// </summary>
        /// <param name="teste">Novo valor de saldo</param>
        /// <param name="id">Id do usuario logado</param>
        /// <returns></returns>
        Usuario AtualizarSaldo(saldoViewModel teste, int id);


        List<Bicicletario> ListarPontosProxixmos(double Latitude, double Longitude, int metros = 1000);
    }
}
