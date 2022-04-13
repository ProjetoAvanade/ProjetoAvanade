using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using Senai_ProjetoAvanade_webAPI.Context;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class VagasRepository : IVagasRepository
    {
        private readonly AvanadeContext ctx;

        public VagasRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(int id, vagasViewModel status)
        {
            Vaga vagabuscada = ctx.Vagas.FirstOrDefault(c => c.IdVaga == id);

            if (vagabuscada != null)
            {
                vagabuscada.StatusVaga = status.StatusVagas;
            }

            ctx.Vagas.Update(vagabuscada);

            ctx.SaveChanges();
        }

        public List<Vaga> ListarTodas(int id)
        {
            return ctx.Vagas.Where(c => c.IdBicicletario == id).ToList();
        }
    }
}
