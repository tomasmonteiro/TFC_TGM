using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoDeclaracaoService : ServiceBase, ITipoDeclaracaoService
    {
        private readonly ITipoDeclaracaoRepository _tipoDeclaracaoRepository;
        public TipoDeclaracaoService(INotificador notificador, ITipoDeclaracaoRepository tipoDeclaracaoRepository) : base(notificador)
        {
            _tipoDeclaracaoRepository = tipoDeclaracaoRepository;
        }

        public void Add(TipoDeclaracao tipoDeclaracao)
        {
            tipoDeclaracao.DataCriacao = DateTime.Now;
            _tipoDeclaracaoRepository.Add(tipoDeclaracao);
        }

        public TipoDeclaracao BuscarPorTipo(string tipo)
        {
            return _tipoDeclaracaoRepository.BuscarPorTipo(tipo);
        }

        public IEnumerable<TipoDeclaracao> BuscarTodos()
        {
            return _tipoDeclaracaoRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var tipoDeclaracao = _tipoDeclaracaoRepository.GetById(id);
            if (tipoDeclaracao == null)
            {
                Notificar("O Tipo de Declaração que pretende eliminar não existe.");
                return;
            }
            tipoDeclaracao.DataAtualizacao = DateTime.Now;
            tipoDeclaracao.Status = false;
            _tipoDeclaracaoRepository.Update(tipoDeclaracao);
        }

        public IEnumerable<TipoDeclaracao> GetAll()
        {
            return _tipoDeclaracaoRepository.GetAll();
        }

        public TipoDeclaracao GetById(Guid id)
        {
            return _tipoDeclaracaoRepository.GetById(id);
        }

        public void Remove(TipoDeclaracao tDeclaracao)
        {
            var tipoDeclaracao = _tipoDeclaracaoRepository.GetById(tDeclaracao.Id);
            if (tipoDeclaracao == null)
            {
                Notificar("O Tipo de Declaração que pretende eliminar não existe.");
                return;
            }
            _tipoDeclaracaoRepository.Remove(tipoDeclaracao);
        }

        public void Update(TipoDeclaracao tipoDeclaracao)
        {
            tipoDeclaracao.DataAtualizacao = DateTime.Now;
            _tipoDeclaracaoRepository.Update(tipoDeclaracao);
        }

        public void Dispose()
        {
            _tipoDeclaracaoRepository.Dispose();
        }
    }
}
