using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using CPF_CACL.GestaoSocio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IOrganismoService 
    {
        IEnumerable<Organismo> BuscarTodos();

        //Iterface Base de Serviços
        public void Add(Organismo organismo);
        Organismo GetById(int id);
        IEnumerable<Organismo> GetAll();
        void Update(Organismo organismo);
        void Eliminar(int id);
        void Remove(Organismo organismo);
        void Dispose();
    }
}
