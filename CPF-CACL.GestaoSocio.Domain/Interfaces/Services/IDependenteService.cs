using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IDependenteService : IServiceBase<Dependente>
    {
   
        //Método para verificar se já existe um conjuge para aquele Sócio
        bool VerificarExisteConjuge(Guid socioId);

		IEnumerable<Dependente> BuscarAgregadoPorSocio(Guid socioId);

	}
}
