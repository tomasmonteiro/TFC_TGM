using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoItemService : ServiceBase, ITipoItemService
    {
        private readonly ITipoItemRepository _tipoItemRepository;
        public TipoItemService(ITipoItemRepository tipoItemRepository, INotificador notificador) : base(notificador)
        {
            _tipoItemRepository = tipoItemRepository;
        }

        public void Add(TipoItem tipoItem)
        {
            if (_tipoItemRepository.Find(a => a.Descricao == tipoItem.Descricao && a.Status == true ).Count() > 0)
            {
                Notificar("Já existe um Tipo de Item com esta Descrição.");
                return;
            }
            _tipoItemRepository.Add(tipoItem);
        }

        public ICollection< TipoItem> BuscarPorNome(string nome)
        {
            return _tipoItemRepository.BuscarPorNome(nome).ToList();
        }

        public IEnumerable<TipoItem> BuscarTodos()
        {
            return _tipoItemRepository.BuscarTodos();
        }

        public void Dispose()
        {
            _tipoItemRepository.Dispose();
        }

        public void Eliminar(Guid id)
        {
            var tipoItem = _tipoItemRepository.GetById(id);
            if (tipoItem == null)
            {
                Notificar("O Item que pretende eliminar não existe");
                return;
            }
            tipoItem.Status = false;
            Update(tipoItem);
        }

        public IEnumerable<TipoItem> GetAll()
        {
            return _tipoItemRepository.GetAll();
        }

        public TipoItem GetById(Guid id)
        {
            return _tipoItemRepository.GetById(id);
        }

        public void Remove(TipoItem tipoItem)
        {
            _tipoItemRepository.Remove(tipoItem);
        }

        public void Update(TipoItem tipoItem)
        {
            tipoItem.DataAtualizacao = DateTime.Now;
            _tipoItemRepository.Update(tipoItem);
        }
    }
}
