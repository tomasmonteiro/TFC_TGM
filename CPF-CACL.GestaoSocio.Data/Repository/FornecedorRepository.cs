using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Data.Repository;
using CPF_CACL.GestaoSocio.Domain.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        private readonly GSContext _gsContext;
        public FornecedorRepository(GSContext gsContext) : base(gsContext)
        {
            _gsContext = gsContext;
        }

        public Fornecedor BuscarPorCodigo(string codigo)
        {
            return _gsContext.Fornecedor.Where(p => p.Cod == codigo && p.Status == true).FirstOrDefault();
        }

        public Fornecedor BuscarPorNif(string nif)
        {
            return _gsContext.Fornecedor.Where(p => p.NIF == nif && p.Status == true).FirstOrDefault();
        }

        public Fornecedor BuscarPorNome(string nome)
        {
            return _gsContext.Fornecedor.Where(p => p.Nome == nome && p.Status == true).FirstOrDefault();
        }

        public IEnumerable<Fornecedor> BuscarTodos()
        {
            return _gsContext.Fornecedor.Where(p => p.Status == true);
        }

        public string ConsultarUltimoCodigo(string tipoEntidade)
        {
            var ultimoCodigo = _gsContext.Fornecedor
            .Where(p => p.Cod.StartsWith($"{tipoEntidade}"))
            .OrderByDescending(p => p.Cod)
            .Select(p => p.Cod)
            .FirstOrDefault();

            return ultimoCodigo;
        }

        public int ContarFornecedores()
        {
            return _gsContext.Fornecedor.Count(p => p.Status == true);
        }
    }
}
