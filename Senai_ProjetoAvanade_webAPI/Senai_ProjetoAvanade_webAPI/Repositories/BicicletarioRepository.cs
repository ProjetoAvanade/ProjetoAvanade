using Senai_ProjetoAvanade_webAPI.Contexts;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class BicicletarioRepository : IBicicletarioRepository
    {

        private readonly AvanadeContext ctx;

        public BicicletarioRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        public Bicicletario Buscar(int id)
        {
            return ctx.Bicicletarios.FirstOrDefault(c => c.IdBicicletario == id);
        }

        public void Cadastrar(Bicicletario bicicletarionovo)
        {
            ctx.Bicicletarios.Add(bicicletarionovo);

            ctx.SaveChanges();
        }

        public List<Bicicletario> Listar()
        {
            return ctx.Bicicletarios.ToList();
        }
    }
}
