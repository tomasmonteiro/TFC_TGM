using System.Linq.Expressions;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Iterface Base contendo o CRUD padrão
        void Add(TEntity obj);
        TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}
