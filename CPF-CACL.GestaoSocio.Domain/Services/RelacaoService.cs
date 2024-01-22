using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class RelacaoService : ServiceBase, IRelacaoService
    {
        private readonly IRelacaoRepository _relacaoRepository;
        public RelacaoService(IRelacaoRepository relacaoRepository, INotificador notificador) : base(notificador)
        {
            _relacaoRepository = relacaoRepository;
        }

        public void Add(Relacao relacao)
        {
            relacao.DataCriacao = DateTime.Now;
            _relacaoRepository.Add(relacao);
        }

        public IEnumerable<Relacao> BuscarTodos()
        {
            return _relacaoRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {

            Relacao relacao = _relacaoRepository.GetById(id);
            if (relacao == null)
            {
                Notificar("A Relação que pretende eliminar não existe.");
                return;
            }
            relacao.Status = false;
            Update(relacao);
        }

        public IEnumerable<Relacao> GetAll()
        {
            return _relacaoRepository.GetAll();
        }

        public Relacao GetById(Guid id)
        {
            return _relacaoRepository.GetById(id);
        }

        public void Update(Relacao relacao)
        {
            relacao.DataAtualizacao = DateTime.Now;
            _relacaoRepository.Update(relacao);
        }
        public void Dispose()
        {
            _relacaoRepository.Dispose();
        }

        public void Remove(Relacao relacao)
        {
            _relacaoRepository.Remove(relacao);
        }
    }
}
