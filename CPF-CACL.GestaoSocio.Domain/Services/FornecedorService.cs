using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class FornecedorService : ServiceBase, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository,INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void Add(Fornecedor fornecedor)
        {
            fornecedor.Cod = GerarDodigoDoFornecedor();
            _fornecedorRepository.Add(fornecedor);
        }

        public Fornecedor BuscarPorCod(string codigo)
        {
            return _fornecedorRepository.BuscarPorCodigo(codigo);
        }

        public Fornecedor BuscarPorNif(string nif)
        {
            return _fornecedorRepository.BuscarPorNif(nif);
        }

        public IEnumerable<Fornecedor> BuscarTodos()
        {
            return _fornecedorRepository.BuscarTodos();
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _fornecedorRepository.GetAll();
        }

        public Fornecedor GetById(Guid id)
        {
            return _fornecedorRepository.GetById(id);
        }
        public void Eliminar(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                Notificar("O Fornecedor que pretende eliminar não existe.");
                return;
            }
            fornecedor.Status = false;
            Update(fornecedor);
        }

        public void Remove(Fornecedor fornecedor)
        {
            var novoFornecedor = _fornecedorRepository.GetById(fornecedor.Id);
            if (novoFornecedor == null)
            {
                Notificar("O Fornecedor que pretende eliminar não existe.");
                return;
            }
            _fornecedorRepository.Remove(novoFornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            fornecedor.DataAtualizacao = DateTime.Now;
            _fornecedorRepository.Update(fornecedor);
        }
        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }


        public string GerarDodigoDoFornecedor()
        {
            string tipoEntidade = "F";

            var ultimoCodigo = _fornecedorRepository.ConsultarUltimoCodigo(tipoEntidade);

            int proximoNumero = 1;

            if (ultimoCodigo != null)
            {
                proximoNumero = int.Parse(ultimoCodigo.Substring(tipoEntidade.Length)) + 1;
            }
            return $"{tipoEntidade}{proximoNumero:D4}";
        }

        public Fornecedor BuscarPorNome(string nome)
        {
            return _fornecedorRepository.BuscarPorNome(nome);
        }
    }
}
