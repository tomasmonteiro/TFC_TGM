using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class BairroService : ServiceBase, IBairroService
    {
        private readonly IBairroRepository _bairroRepository;
        public BairroService(IBairroRepository bairroRepository, INotificador notificador) : base(notificador)
        {
            _bairroRepository = bairroRepository;
        }

        public IEnumerable<Bairro> BuscarTodos()
        {
            return _bairroRepository.BuscarTodos();
        }


        public void Add(Bairro bairro)
        {
            bairro.DataCriacao = DateTime.Now;
            if (_bairroRepository.Find(a => a.Nome == bairro.Nome && a.MunicipioId == bairro.MunicipioId && a.Status == true).Count() > 0)
            {
                Notificar("Já existe um Bairro definido com este nome, neste Município.");
                return;
            }
            _bairroRepository.Add(bairro);
        }

        public IEnumerable<Bairro> GetAll()
        {
            return _bairroRepository.GetAll();
        }

        public Bairro GetById(Guid id)
        {
            return _bairroRepository.GetById(id);
        }

        public void Update(Bairro bairro)
        {
            bairro.DataAtualizacao = DateTime.Now;
            _bairroRepository.Update(bairro);
        }
        public void Eliminar(Guid id)
        {
            Bairro bairro = GetById(id);
            if (bairro == null)
            {
                Notificar("O Bairro que pretende eliminar não existe.");
                return;
            }
            bairro.Status = false;
            Update(bairro);
        }

        public void Dispose()
        {
            _bairroRepository.Dispose();
        }

        public void Remove(Bairro bairro)
        {
            var novoBairro = _bairroRepository.GetById(bairro.Id);
            if (novoBairro== null)
            {
                Notificar("O Bairro que pretende eliminar não existe.");
                return;
            }
            _bairroRepository.Remove(novoBairro);
        }
    }
}
