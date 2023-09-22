using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly GSContext _gsContext;
        public void Add(TEntity obj)
        {
            _gsContext.Set<TEntity>().Add(obj);
            _gsContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _gsContext.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return _gsContext.Set<TEntity>().Find(id);
        }
        public void Remove(TEntity obj)
        {
            _gsContext.Set<TEntity>().Remove(obj);
            _gsContext.SaveChanges();
        }
        public void Update(TEntity obj)
        {
            _gsContext.Entry(obj).State = EntityState.Modified;
            _gsContext.SaveChanges();
        }
    }
}
