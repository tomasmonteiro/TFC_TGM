using CPF_CACL.GestaoSocio.Domain.Models.Entities;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface ISocioService
    {
        IEnumerable<Socio> BuscarPorNome(string nome);
        IEnumerable<Socio> BuscarTodos();
        //Iterface Base de Serviços
        public void Add(Socio socio);
        Socio GetById(int id);
        IEnumerable<Socio> GetAll();
        void Update(Socio socio);
        void Eliminar(int id);
        void Remove(Socio socio);
        void Dispose();
    }
}
