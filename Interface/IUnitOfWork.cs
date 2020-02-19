using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IExpenseTypeRepository ExpenseType { get; }
        #endregion

        Task Commit();
        Task SaveChangesAsync();
        void Begin(IsolationLevel isolationLevel);
    }
}
