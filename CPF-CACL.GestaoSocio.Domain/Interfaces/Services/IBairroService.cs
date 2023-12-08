using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IBairroService 
    {
        IEnumerable<Bairro> BuscarTodos();

        //Iterface Base de Serviços
        public void Add(Bairro bairro);
        Bairro GetById(int id);
        IEnumerable<Bairro> GetAll();
        void Update(Bairro bairro);
        void Eliminar(int id);
        void Dispose();
    }
}
