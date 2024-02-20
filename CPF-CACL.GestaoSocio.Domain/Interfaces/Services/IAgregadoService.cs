using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IAgregadoService : IServiceBase<Agregado>
    {
   
        //Método para verificar se já existe um conjuge para aquele Sócio
        bool VerificarExisteConjuge(Guid socioId);

		IEnumerable<Agregado> BuscarAgregadoPorSocio(Guid socioId);

	}
}
