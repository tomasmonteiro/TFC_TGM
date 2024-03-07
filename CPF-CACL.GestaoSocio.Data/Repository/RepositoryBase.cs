using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Entities;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

//Classe abstrata contendo a base do CRUD para as classes concretas do Repositório

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity, new()
    {
        protected GSContext _gsContext;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(GSContext gsContext)
        {
            _gsContext = gsContext;
            DbSet = gsContext.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            _gsContext.SaveChanges();
        }
        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
       public void Update(TEntity obj)
        {
            _gsContext.Entry(obj).State = EntityState.Modified;
            _gsContext.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            DbSet.Attach(obj);
            DbSet.Remove(obj);
            _gsContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _gsContext.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }
    }
}
