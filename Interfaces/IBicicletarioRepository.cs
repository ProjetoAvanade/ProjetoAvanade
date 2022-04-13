using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    public interface IBicicletarioRepository //Precisa ser publica para que a injecao de dependencia possa acessar
    {
        void Cadastrar(bicicletarioViewModel bicicletarionovo);

        List<Bicicletario> Listar();

        Bicicletario Buscar(int id);
    }
}
