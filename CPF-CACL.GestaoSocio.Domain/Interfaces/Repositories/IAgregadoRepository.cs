using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IAgregadoRepository : IRepositoryBase<Agregado>
    {
        IEnumerable<Agregado> BuscarTodos();

        //Método para virificar se existe algum conjuge no Sócio
        bool VerificarExisteConjuge(Guid socioId);
    }
}
