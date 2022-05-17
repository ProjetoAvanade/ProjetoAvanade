using Senai_ProjetoAvanade_webAPI.ViewModels;

namespace Senai_ProjetoAvanade_webAPI.Interfaces
{
    public interface IStatusPagamentoRepository
    {
        void Atualizar(int id, statuspagamentoViewModel StatusAtualizada);
    }
}
