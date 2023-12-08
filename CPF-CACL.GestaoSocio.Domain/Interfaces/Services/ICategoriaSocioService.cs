using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ICategoriaSocioService 
    {
        IEnumerable<CategoriaSocio> BuscarTodos();
        //Iterface Base de Serviços
        public void Add(CategoriaSocio categoriaSocio);
        CategoriaSocio GetById(int id);
        IEnumerable<CategoriaSocio> GetAll();
        void Update(CategoriaSocio categoriaSocio);
        void Eliminar(int id);
        void Remove(CategoriaSocio categoriaSocio);
        void Dispose();
    }
}
