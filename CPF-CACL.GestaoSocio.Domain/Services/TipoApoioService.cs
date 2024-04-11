using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoApoioService : ServiceBase, ITipoApoioService
    {
        private readonly ITipoApoioRepository _tipoApoioRepository;
        public TipoApoioService( INotificador notificador, ITipoApoioRepository tipoApoioRepository) : base(notificador)
        {
            _tipoApoioRepository = tipoApoioRepository;
        }

        public void Add(TipoApoio tipoApoio)
        {
            tipoApoio.DataCriacao = DateTime.Now;
            _tipoApoioRepository.Add(tipoApoio);
        }

        public TipoApoio BuscarPorTipo(string tipo)
        {
            return _tipoApoioRepository.BuscarPorTipo(tipo);
        }

        public IEnumerable<TipoApoio> BuscarTodos()
        {
            return _tipoApoioRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var tipoApoio = _tipoApoioRepository.GetById(id);
            if (tipoApoio == null)
            {
                Notificar("O Tipo de Apoio que pretende eliminar não existe.");
                return;
            }
            tipoApoio.DataAtualizacao = DateTime.Now;
            tipoApoio.Status = false;
            _tipoApoioRepository.Update(tipoApoio);
        }

        public IEnumerable<TipoApoio> GetAll()
        {
            return _tipoApoioRepository.GetAll();
        }

        public TipoApoio GetById(Guid id)
        {
            return _tipoApoioRepository.GetById(id);
        }

        public void Remove(TipoApoio tApoio)
        {
            var tipoApoio = _tipoApoioRepository.GetById(tApoio.Id);
            if (tipoApoio == null)
            {
                Notificar("O Tipo de Apoio que pretende eliminar não existe.");
                return;
            }
            _tipoApoioRepository.Remove(tipoApoio);
        }

        public void Update(TipoApoio tipoApoio)
        {
            tipoApoio.DataAtualizacao = DateTime.Now;
            _tipoApoioRepository.Update(tipoApoio);
        }

        public void Dispose()
        {
            _tipoApoioRepository.Dispose();
        }
    }
}
