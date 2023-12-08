using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Services;
using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Models.Validation;
using CPF_CACL.GestaoSocio.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Services
{

    public class MunicipioService : ServiceBase, IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;
        public MunicipioService(IMunicipioRepository municipioRepository, INotificador notificador) : base(notificador)
        {
            _municipioRepository = municipioRepository;
        }

        public IEnumerable<Municipio> BuscarTodos()
        {
            return _municipioRepository.BuscarTodos();
        }


        public void Add(Municipio municipio)
        {
            //if (!ExecutarValidacao(new MunicipioValidation(), municipio)) return;
            if (_municipioRepository.Find(a => a.Nome == municipio.Nome && a.Status == true).Count() > 0)
            {
                Notificar("Já existe um Município definido com este nome.");
                return;
            }
            _municipioRepository.Add(municipio);
        }
        public IEnumerable<Municipio> GetAll()
        {
            return _municipioRepository.GetAll();
        }
        public Municipio GetById(int id)
        {
            return _municipioRepository.GetById(id);
        }
        public void Update(Municipio municipio)
        {
            //if (!ExecutarValidacao(new MunicipioValidation(), municipio)) return;
            municipio.DataAtualizacao = DateTime.Now;
            _municipioRepository.Update(municipio);
        }
        public void Remove(Municipio municipio)
        {
            _municipioRepository.Remove(municipio);
        }
        public void Eliminar(int id)
        {
            Municipio municipio = GetById(id);
            if (municipio == null)
            {
                Notificar("O Município que pretende eliminar não existe.");
                return;
            }
            municipio.Status = false;
            _municipioRepository.Update(municipio);
        }
        public void Dispose()
        {
            _municipioRepository.Dispose();
        }
    }
}
