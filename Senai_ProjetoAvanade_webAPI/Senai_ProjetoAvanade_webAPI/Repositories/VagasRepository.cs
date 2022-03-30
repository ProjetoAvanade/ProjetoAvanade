using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class VagasRepository : IVagasRepository
    {
        AvanadeContext ctx = new AvanadeContext();
        public List<Vaga> ListarTodas(int id)
        {
            return ctx.Vagas.Where(c => c.IdBicicletario == id).ToList();
        }
    }
}
