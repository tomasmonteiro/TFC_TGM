using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class TipoEmolumentoService : ServiceBase, ITipoEmolumentoService
    {
        private readonly ITipoEmolumentoRepository _tipoItemRepository;
        public TipoEmolumentoService(ITipoEmolumentoRepository tipoItemRepository, INotificador notificador) : base(notificador)
        {
            _tipoItemRepository = tipoItemRepository;
        }

        public void Add(TipoEmolumento tipoItem)
        {
            if (_tipoItemRepository.Find(a => a.Descricao == tipoItem.Descricao && a.Status == true ).Count() > 0)
            {
                Notificar("Já existe um Tipo de Emolumento com esta Descrição.");
                return;
            }
            _tipoItemRepository.Add(tipoItem);
        }

        public ICollection< TipoEmolumento> BuscarPorNome(string nome)
        {
            return _tipoItemRepository.BuscarPorNome(nome).ToList();
        }

        public IEnumerable<TipoEmolumento> BuscarTodos()
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
                Notificar("O Emolumento que pretende eliminar não existe");
                return;
            }
            tipoItem.Status = false;
            Update(tipoItem);
        }

        public IEnumerable<TipoEmolumento> GetAll()
        {
            return _tipoItemRepository.GetAll();
        }

        public TipoEmolumento GetById(Guid id)
        {
            return _tipoItemRepository.GetById(id);
        }

        public void Remove(TipoEmolumento tipoItem)
        {
            var novoTipo = _tipoItemRepository.GetById(tipoItem.Id);
            if (novoTipo == null)
            {
                Notificar("O Tipo de Emolumento que pretende eliminar não existe.");
                return;
            }
            _tipoItemRepository.Remove(novoTipo);
        }

        public void Update(TipoEmolumento tipoItem)
        {
            tipoItem.DataAtualizacao = DateTime.Now;
            _tipoItemRepository.Update(tipoItem);
        }
    }
}
