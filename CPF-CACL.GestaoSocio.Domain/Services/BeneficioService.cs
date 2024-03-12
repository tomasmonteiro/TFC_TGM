using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{
    public class BeneficioService : ServiceBase, IBeneficioService
    {
        private readonly IBeneficioRepository _beneficioRepository;
        public BeneficioService(IBeneficioRepository beneficioRepository, INotificador notificador) : base(notificador)
        {
            _beneficioRepository = beneficioRepository;
        }

        public void Add(Beneficio beneficio)
        {
            beneficio.DataCriacao = DateTime.Now;
            if (_beneficioRepository.Find(a => a.Nome == beneficio.Nome && a.TipoBeneficioId == beneficio.TipoBeneficioId && a.Status == true).Count() > 0)
            {
                Notificar("O Benefício que pretende adicionar já existe.");
                return;
            }
            _beneficioRepository.Add(beneficio);
        }
        public IEnumerable<Beneficio> BuscarPorTipo(Guid tipoBeneficioId)
        {
            return _beneficioRepository.BuscarPorTipo(tipoBeneficioId);
        }
        public IEnumerable<Beneficio> BuscarTodos()
        {
            return _beneficioRepository.BuscarTodos();
        }
        public void Eliminar(Guid id)
        {
            var beneficio = _beneficioRepository.GetById(id);
            if (beneficio == null)
            {
                Notificar("O Beneficio que pretende inativar não existe.");
                return;
            }
            beneficio.Status = false;
            beneficio.DataAtualizacao = DateTime.Now;
            _beneficioRepository.Update(beneficio);
        }

        public IEnumerable<Beneficio> GetAll()
        {
            return _beneficioRepository.GetAll();
        }

        public Beneficio GetById(Guid id)
        {
            return _beneficioRepository.GetById(id);
        }

        public void Remove(Beneficio benef)
        {
            var beneficio = _beneficioRepository.GetById(benef.Id);
            if (beneficio == null)
            {
                Notificar("O Beneficio que pretende eliminar não existe.");
                return;
            }
            _beneficioRepository.Remove(beneficio);
        }

        public void Update(Beneficio beneficio)
        {
            beneficio.DataAtualizacao = DateTime.Now;
            _beneficioRepository.Update(beneficio);
        }
        public void Dispose()
        {
            _beneficioRepository.Dispose();
        }
    }
}
