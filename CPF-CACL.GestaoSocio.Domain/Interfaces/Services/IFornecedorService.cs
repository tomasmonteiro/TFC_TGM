using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IFornecedorService: IServiceBase<Fornecedor>
    {

        Fornecedor BuscarPorNome(string nome);
        Fornecedor BuscarPorCod(string codigo);
        Fornecedor BuscarPorNif(string nif);

    }
}
