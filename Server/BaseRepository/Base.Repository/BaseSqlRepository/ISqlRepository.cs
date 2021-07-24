using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.Repository.Models;

namespace Base.Repository.BaseSqlRepository
{
    public interface ISqlRepository<TEntity> : IDisposable where TEntity : Entity, new()
    {         
        Task<TEntity> Save(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> GetById(long id);
        Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task Delete(TEntity entity);

    }
}