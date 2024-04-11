using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class SolicitacaoDeclaracaoService : ServiceBase, ISolicitacaoDeclaracaoService
    {
		private readonly ISolicitacaoDeclaracaoRepository _solicitacaoDeclaracaoRepository;
		public SolicitacaoDeclaracaoService(ISolicitacaoDeclaracaoRepository solicitacaoDeclaracaoRepository, INotificador notificador) : base(notificador)
		{
            _solicitacaoDeclaracaoRepository = solicitacaoDeclaracaoRepository;
		}

		public void Add(SolicitacaoDeclaracao solicitacaoDeclaracao)
		{
			solicitacaoDeclaracao.EstadoSolicitacao = Enums.EEstadoSolicitacao.Pendente;
			_solicitacaoDeclaracaoRepository.Add(solicitacaoDeclaracao);
		}


        public IEnumerable<SolicitacaoDeclaracao> BuscarTodos()
		{
			return _solicitacaoDeclaracaoRepository.BuscarTodos();
		}

		public void Dispose()
		{
            _solicitacaoDeclaracaoRepository.Dispose();
		}

		public void Eliminar(Guid id)
		{

			var solicitacaoDeclaracao = _solicitacaoDeclaracaoRepository.GetById(id);
			if (solicitacaoDeclaracao == null)
			{
				Notificar("A Solicitação de Declaração que pretende inativar não existe.");
				return;
			}
            solicitacaoDeclaracao.Status = false;
            solicitacaoDeclaracao.DataAtualizacao = DateTime.Now;
            _solicitacaoDeclaracaoRepository.Update(solicitacaoDeclaracao);
		}

		public IEnumerable<SolicitacaoDeclaracao> GetAll()
		{
			return _solicitacaoDeclaracaoRepository.GetAll();
		}

		public SolicitacaoDeclaracao GetById(Guid id)
		{
			return _solicitacaoDeclaracaoRepository.GetById(id);
		}

		public void Remove(SolicitacaoDeclaracao solicitacaoDeclaracao)
		{

			var novaSolicitacaoDeclaracao = _solicitacaoDeclaracaoRepository.GetById(solicitacaoDeclaracao.Id);
			if (novaSolicitacaoDeclaracao == null)
			{
				Notificar("A Solicitação de Declaração que pretende eliminar não existe.");
				return;
			}
            _solicitacaoDeclaracaoRepository.Remove(novaSolicitacaoDeclaracao);
		}

		public void Update(SolicitacaoDeclaracao solicitacaoDeclaracao)
		{
            solicitacaoDeclaracao.DataAtualizacao = DateTime.Now;
            _solicitacaoDeclaracaoRepository.Update(solicitacaoDeclaracao);
		}


        public IEnumerable<SolicitacaoDeclaracao> BuscarSDPendentes()
        {
            return _solicitacaoDeclaracaoRepository.BuscarSDPendentes();
        }
        public IEnumerable<SolicitacaoDeclaracao> BuscarSDConcluidos()
        {
            return _solicitacaoDeclaracaoRepository.BuscarSDConcluidos();
        }
    }
}
