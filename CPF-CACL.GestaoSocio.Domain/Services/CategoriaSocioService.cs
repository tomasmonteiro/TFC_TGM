using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Models.Validation;
using CPF_CACL.GestaoSocio.Domain.Notifications;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class CategoriaSocioService : ServiceBase, ICategoriaSocioService
    {
        private readonly ICategoriaSocioRepository _categoriaSocioRepository;
        public CategoriaSocioService(ICategoriaSocioRepository categoriaSocioRepository, INotificador notificador) : base(notificador)
        {
            _categoriaSocioRepository = categoriaSocioRepository;
        }

        public IEnumerable<CategoriaSocio> BuscarTodos()
        {
            return _categoriaSocioRepository.BuscarTodos();
        }

        public void Add(CategoriaSocio categoriaSocio)
        {
            //if (!ExecutarValidacao(new CategoriaValidation(), categoriaSocio)) return;
            if (_categoriaSocioRepository.Find(a => a.Nome == categoriaSocio.Nome && a.Status == true).Count() > 0)
            {
                Notificar("Já existe uma Categoria definida com este nome.");
                return;
            }
            _categoriaSocioRepository.Add(categoriaSocio);
        }
        public IEnumerable<CategoriaSocio> GetAll()
        {
            return _categoriaSocioRepository.GetAll();
        }
        public CategoriaSocio GetById(int id)
        {
            return _categoriaSocioRepository.GetById(id);
        }
        public void Update(CategoriaSocio categoriaSocio)
        {
            //if (!ExecutarValidacao(new CategoriaValidation(), categoriaSocio)) return;
            categoriaSocio.DataAtualizacao = DateTime.Now;
            _categoriaSocioRepository.Update(categoriaSocio);
        }
        public void Remove(CategoriaSocio categoriaSocio)
        {
            _categoriaSocioRepository.Remove(categoriaSocio);
        }
        public void Eliminar(int id)
        {
            CategoriaSocio categoria = GetById(id);
            if (categoria == null)
            {
                Notificar("A Categoria que pretende eliminar não existe.");
                return;
            }
            categoria.Status = false;
            _categoriaSocioRepository.Update(categoria);
        }
        public void Dispose()
        {
            _categoriaSocioRepository.Dispose();

        }
    }
}
