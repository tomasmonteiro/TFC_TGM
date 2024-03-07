using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Fornecedor BuscarPorNome(string nome);
        Fornecedor BuscarPorCodigo(string codigo);
        Fornecedor BuscarPorNif(string nif);
        IEnumerable<Fornecedor> BuscarTodos();
        public string ConsultarUltimoCodigo(string tipoEntidade);
        int ContarFornecedores();
    }
}
