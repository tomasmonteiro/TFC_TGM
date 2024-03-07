using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{

    public class OrganismoService : ServiceBase, IOrganismoService
    {
        private readonly IOrganismoRepository _organismoRepository;

        public OrganismoService(IOrganismoRepository organismoRepository, INotificador notificador) 
            : base(notificador)
        {
            _organismoRepository = organismoRepository;
        }

        public IEnumerable<Organismo> BuscarTodos()
        {
            return _organismoRepository.BuscarTodos();
        }
        public void Add(Organismo organismo)
        {
            //if (!ExecutarValidacao(new OrganismoValidation(), municipio)) return;
            if (_organismoRepository.Find(a => a.Nome == organismo.Nome && a.Status == true).Count() > 0)
            {
                Notificar("Já existe um Organismo definido com este nome.");
                return;
            }
            _organismoRepository.Add(organismo);
        }
        public IEnumerable<Organismo> GetAll()
        {
            return _organismoRepository.GetAll();
        }
        public Organismo GetById(Guid id)
        {
            return _organismoRepository.GetById(id);
        }
        public void Update(Organismo organismo)
        {
            //if (!ExecutarValidacao(new OrganismoValidation(), organismo)) return;
            organismo.DataAtualizacao = DateTime.Now;
            _organismoRepository.Update(organismo);
        }
        public void Remove(Organismo organismo)
        {
            var novoOrganismo = _organismoRepository.GetById(organismo.Id);
            if (novoOrganismo == null)
            {
                Notificar("O Organismo que pretende eliminar não existe.");
                return;
            }
            _organismoRepository.Remove(novoOrganismo);
        }
        public void Eliminar(Guid id)
        {
            Organismo organismo = GetById(id);
            if (organismo == null)
            {
                Notificar("O Organismo que pretende eliminar não existe.");
                return;
            }
            organismo.Status = false;
            _organismoRepository.Update(organismo);
        }
        public void Dispose()
        {
            _organismoRepository.Dispose();

        }
    }
}
