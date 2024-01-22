using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IFornecedorService: IServiceBase<Fornecedor>
    {

        //Iterface Base de Serviços
        Fornecedor BuscarPorCod(string codigo);

    }
}
