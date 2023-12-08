using CPF_CACL.GestaoSocio.Data.Context;
using CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

//Classe abstrata contendo a base do CRUD para as classes concretas do Repositório

namespace CPF_CACL.GestaoSocio.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected GSContext _gsContext;

        public RepositoryBase(GSContext gsContext)
        {
            _gsContext = gsContext;
        }
        public void Add(TEntity obj)
        {
            _gsContext.Set<TEntity>().Add(obj);
            _gsContext.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            return _gsContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _gsContext.Set<TEntity>().ToList();
        }
       public void Update(TEntity obj)
        {
            _gsContext.Entry(obj).State = EntityState.Modified;
            _gsContext.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            _gsContext.Set<TEntity>().Remove(obj);
            _gsContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _gsContext.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _gsContext.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
