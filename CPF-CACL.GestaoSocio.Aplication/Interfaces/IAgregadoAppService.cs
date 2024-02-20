using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IAgregadoAppService
    {
        public void Adicionar(AgregadoViewModel agregado);

        public IEnumerable<AgregadoViewModel> Buscar();
        IEnumerable<AgregadoViewModel> BuscarAgregadoPorSocio(Guid socioId);
		public void Atualizar(AgregadoViewModel bairro);
        public void Eliminar(Guid id);
    }
}
