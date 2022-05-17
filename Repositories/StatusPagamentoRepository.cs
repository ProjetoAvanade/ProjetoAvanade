using Senai_ProjetoAvanade_webAPI.Context;
using Senai_ProjetoAvanade_webAPI.Domains;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.ViewModels;
using System.Linq;

namespace Senai_ProjetoAvanade_webAPI.Repositories
{
    public class StatusPagamentoRepository : IStatusPagamentoRepository
    {
        private readonly AvanadeContext ctx;

        public StatusPagamentoRepository(AvanadeContext appContext)
        {
            ctx = appContext;
        }
        public void Atualizar(int id, statuspagamentoViewModel StatusAtualizada)
        {
            Reserva reservaBuscada = ctx.Reservas.FirstOrDefault(x => x.IdReserva == id);

            if (reservaBuscada != null)
            {
                reservaBuscada.StatusPagamento = StatusAtualizada.statuspagamento;
            }

            ctx.Reservas.Update(reservaBuscada);

            ctx.SaveChanges();
        }
    }
}
