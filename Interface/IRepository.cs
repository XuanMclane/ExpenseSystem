using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity 
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> FindById(long id);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(long id);
        Task<IEnumerable<TEntity>> FindAll();
        IQueryable<TEntity> GetAll();
    }
}
