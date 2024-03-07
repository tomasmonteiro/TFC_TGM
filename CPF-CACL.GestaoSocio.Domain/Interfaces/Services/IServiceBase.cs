namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> BuscarTodos();
        public void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Eliminar(Guid id);
        void Remove(TEntity obj);
        void Dispose();
    }
}
