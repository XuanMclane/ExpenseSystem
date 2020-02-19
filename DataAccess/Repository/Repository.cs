using DataAccess;
using Entity;
using ExpenseSystem.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected ExpenseDBContext Context { get; }
        private readonly DbSet<TEntity> _dbSet;
        public Repository(ExpenseDBContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            EntityEntry entityEntry = Context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                await _dbSet.AddAsync(entity);
            }
            else
            {
                entityEntry.State = EntityState.Added;
            }
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> FindById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var originalEntity = await _dbSet.FindAsync(entity.Id);
            if (originalEntity == null) return null;
            Context.Entry(originalEntity).CurrentValues.SetValues(entity);
            Context.Entry(originalEntity).State = EntityState.Modified;
            Context.Entry(originalEntity).Property(x => x.CreatedBy).IsModified = false;
            Context.Entry(originalEntity).Property(x => x.CreationTimeStamp).IsModified = false;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(long id)
        {
            var originalEntity = await _dbSet.FindAsync(id);
            if (originalEntity == null) return false;
            originalEntity.IsDeleted = false;
            Context.Entry(originalEntity).CurrentValues.SetValues(originalEntity);
            Context.Entry(originalEntity).State = EntityState.Modified;
            Context.Entry(originalEntity).Property(x => x.CreatedBy).IsModified = false;
            Context.Entry(originalEntity).Property(x => x.CreationTimeStamp).IsModified = false;
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> FindAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
    }
}
