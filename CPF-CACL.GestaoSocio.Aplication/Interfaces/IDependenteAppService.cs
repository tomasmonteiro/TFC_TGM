using CPF_CACL.GestaoSocio.Aplication.ViewModel;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Aplication.Interfaces
{
    public interface IDependenteAppService
    {
        public void Adicionar(DependenteViewModel dependente);

        public IEnumerable<DependenteViewModel> Buscar();
        IEnumerable<DependenteViewModel> BuscarDependentePorSocio(Guid socioId);
		public void Atualizar(DependenteViewModel bairro);
        public void Eliminar(Guid id);
    }
}
