using CPF_CACL.GestaoSocio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPF_CACL.GestaoSocio.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //Iterface Base contendo o CRUD padrão
        void Add(TEntity obj);
        TEntity GetById(int id);
        public IEnumerable<TEntity> GetAll();

        // Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();

    }
}
