using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Base.Repository.BaseSqlRepository
{
    public abstract class SqlRepository<TEntity> : ISqlRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly  DbContext Db;
        private readonly DbSet<TEntity> DbSet;

        protected SqlRepository(DbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
            return Task.FromResult("");            
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual  Task<List<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            var entity = await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public virtual Task<TEntity> Save(TEntity entity)
        {
            entity.DataCriacao = DateTime.Now;
            DbSet.Add(entity);
            Db.SaveChanges();

            return Task.FromResult(entity);
        }

        public virtual Task Update(TEntity entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            DbSet.Update(entity);
            Db.SaveChanges();
            return Task.FromResult("");
        }
    }
}