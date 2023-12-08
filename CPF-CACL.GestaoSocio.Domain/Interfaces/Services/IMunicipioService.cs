using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IMunicipioService
    {
        IEnumerable<Municipio> BuscarTodos();

        //Iterface Base de Serviços
        public void Add(Municipio municipio);
        Municipio GetById(int id);
        IEnumerable<Municipio> GetAll();
        void Update(Municipio municipio);
        void Eliminar(int id);
        void Remove(Municipio municipio);
        void Dispose();
    }
}
