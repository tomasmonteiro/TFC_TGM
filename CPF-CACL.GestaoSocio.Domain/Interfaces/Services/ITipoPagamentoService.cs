using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ITipoPagamentoService 
    {
        IEnumerable<TipoPagamento> BuscarTipos();

        //Iterface Base de Serviços
        public void Add(TipoPagamento tipoPagamento);
        TipoPagamento GetById(int id);
        IEnumerable<TipoPagamento> GetAll();
        void Update(TipoPagamento tipoPagamento);
        void Eliminar(int id);
        void Remove(TipoPagamento tipoPagamento);
        void Dispose();
    }
}
