using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class CapitalService : ServiceBase, ICapitalService
    {
        private readonly ICapitalRepository _capitalRepository;
        public CapitalService( INotificador notificador, ICapitalRepository capitalRepository) : base(notificador)
        {
            _capitalRepository = capitalRepository;
        }

        public void Add(Capital capital)
        {
            capital.DataCriacao = DateTime.Now;
            if (_capitalRepository.Find(a => a.BeneficioId == capital.BeneficioId && a.CategoriaSocioId == capital.CategoriaSocioId && a.Status == true).Count() > 0)
            {
                Notificar("O Capital que pretende adicionar já existe.");
                return;
            }
            _capitalRepository.Add(capital);
        }

        public IEnumerable<Capital> BuscarTodos()
        {
            return _capitalRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var capital = _capitalRepository.GetById(id);
            if (capital == null)
            {
                Notificar("O Capital que pretende inativar não existe.");
                return;
            }
            capital.Status = false;
            capital.DataAtualizacao = DateTime.Now;
            _capitalRepository.Update(capital);
        }
        public IEnumerable<Capital> GetAll()
        {
            return _capitalRepository.GetAll();
        }
        public Capital GetById(Guid id)
        {
            return _capitalRepository.GetById(id);
        }
        public void Remove(Capital capital)
        {
            var novoCapital = _capitalRepository.GetById(capital.Id);
            if (novoCapital == null)
            {
                Notificar("O Capital que pretende eliminar não existe.");
                return;
            }
            _capitalRepository.Remove(novoCapital);
        }
        public void Update(Capital capital)
        {
            capital.DataAtualizacao = DateTime.Now;
            _capitalRepository.Update(capital);
        }
        public void Dispose()
        {
            _capitalRepository.Dispose();
        }

    }
}
