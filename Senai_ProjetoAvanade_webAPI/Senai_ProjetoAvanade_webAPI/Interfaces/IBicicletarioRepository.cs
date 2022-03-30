using Senai_ProjetoAvanade_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    interface IBicicletarioRepository
    {
        void Cadastrar(Bicicletario bicicletarionovo);

        List<Bicicletario> Listar();

        Bicicletario Buscar(int id);
    }
}
