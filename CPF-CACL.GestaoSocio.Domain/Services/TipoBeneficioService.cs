using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoBeneficioService : ServiceBase, ITipoBeneficioService
    {
        private readonly ITipoBeneficioRepository _tipoBeneficioRepository;
        public TipoBeneficioService( INotificador notificador, ITipoBeneficioRepository tipoBeneficioRepository) : base(notificador)
        {
            _tipoBeneficioRepository = tipoBeneficioRepository;
        }

        public void Add(TipoBeneficio tipoBeneficio)
        {
            tipoBeneficio.DataCriacao = DateTime.Now;
            _tipoBeneficioRepository.Add(tipoBeneficio);
        }

        public TipoBeneficio BuscarPorNome(string nome)
        {
            return _tipoBeneficioRepository.BuscarPorNome(nome);
        }

        public IEnumerable<TipoBeneficio> BuscarTodos()
        {
            return _tipoBeneficioRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var tipoBeneficio = _tipoBeneficioRepository.GetById(id);
            if (tipoBeneficio == null)
            {
                Notificar("O Tipo de Benefício que pretende eliminar não existe.");
                return;
            }
            tipoBeneficio.DataAtualizacao = DateTime.Now;
            tipoBeneficio.Status = false;
            _tipoBeneficioRepository.Update(tipoBeneficio);
        }

        public IEnumerable<TipoBeneficio> GetAll()
        {
            return _tipoBeneficioRepository.GetAll();
        }

        public TipoBeneficio GetById(Guid id)
        {
            return _tipoBeneficioRepository.GetById(id);
        }

        public void Remove(TipoBeneficio tBeneficio)
        {
            var tipoBeneficio = _tipoBeneficioRepository.GetById(tBeneficio.Id);
            if (tipoBeneficio == null)
            {
                Notificar("O Tipo de Benefício que pretende eliminar não existe.");
                return;
            }
            _tipoBeneficioRepository.Remove(tipoBeneficio);
        }

        public void Update(TipoBeneficio tipoBeneficio)
        {
            tipoBeneficio.DataAtualizacao = DateTime.Now;
            _tipoBeneficioRepository.Update(tipoBeneficio);
        }

        public void Dispose()
        {
            _tipoBeneficioRepository.Dispose();
        }
    }
}
