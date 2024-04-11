using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Enums;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SolicitacaoApoioService : ServiceBase, ISolicitacaoApoioService
    {
		private readonly ISolicitacaoApoioRepository _solicitacaoApoioRepository;
		public SolicitacaoApoioService(ISolicitacaoApoioRepository solicitacaoApoioRepository, INotificador notificador) : base(notificador)
		{
            _solicitacaoApoioRepository = solicitacaoApoioRepository;
		}

		public void Add(SolicitacaoApoio solicitacaoApoio)
		{
			solicitacaoApoio.EstadoSolicitacao = Enums.EEstadoSolicitacao.Pendente;
            _solicitacaoApoioRepository.Add(solicitacaoApoio);
		}

        public IEnumerable<SolicitacaoApoio> BuscarSAPendentes()
        {
			return _solicitacaoApoioRepository.BuscarSAPendentes();
        }
        public IEnumerable<SolicitacaoApoio> BuscarSAConcluidos()
        {
			return _solicitacaoApoioRepository.BuscarSAConcluidos();
        }

        public IEnumerable<SolicitacaoApoio> BuscarPorTipo(Guid TipoId)
        {
            return _solicitacaoApoioRepository.BuscarPorTipo(TipoId);
        }

        public IEnumerable<SolicitacaoApoio> BuscarTodos()
		{
			return _solicitacaoApoioRepository.BuscarTodos();
		}

		public void Dispose()
		{
            _solicitacaoApoioRepository.Dispose();
		}

		public void Eliminar(Guid id)
		{

			var solicitacaoApoio = _solicitacaoApoioRepository.GetById(id);
			if (solicitacaoApoio == null)
			{
				Notificar("A Solicitação de Apoio que pretende inativar não existe.");
				return;
			}
            solicitacaoApoio.Status = false;
            solicitacaoApoio.DataAtualizacao = DateTime.Now;
            _solicitacaoApoioRepository.Update(solicitacaoApoio);
		}

		public IEnumerable<SolicitacaoApoio> GetAll()
		{
			return _solicitacaoApoioRepository.GetAll();
		}

		public SolicitacaoApoio GetById(Guid id)
		{
			return _solicitacaoApoioRepository.GetById(id);
		}

		public void Remove(SolicitacaoApoio solicitacaoApoio)
		{

			var novaSolicitacaoApoio = _solicitacaoApoioRepository.GetById(solicitacaoApoio.Id);
			if (novaSolicitacaoApoio == null)
			{
				Notificar("A Solicitação de Apoio que pretende eliminar não existe.");
				return;
			}
            _solicitacaoApoioRepository.Remove(novaSolicitacaoApoio);
		}

		public void Update(SolicitacaoApoio solicitacaoApoio)
		{
            solicitacaoApoio.DataAtualizacao = DateTime.Now;
            _solicitacaoApoioRepository.Update(solicitacaoApoio);
		}
	}
}
