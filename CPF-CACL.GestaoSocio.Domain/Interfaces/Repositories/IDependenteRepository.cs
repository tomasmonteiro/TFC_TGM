using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IDependenteRepository : IRepositoryBase<Dependente>
    {
        IEnumerable<Dependente> BuscarTodos();

        //Método para virificar se existe algum conjuge no Sócio
        bool VerificarExisteConjuge(Guid socioId);
        Dependente BuscarConjuge(Guid idSocio);

		IEnumerable<Dependente> BuscarAgregadoPorSocio(Guid socioId);
	}
}
