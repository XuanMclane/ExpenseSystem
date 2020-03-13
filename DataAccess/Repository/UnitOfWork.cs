using DataAccess;
using ExpenseSystem.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExpenseDBContext _context;
        private IDbContextTransaction _transaction;
        private bool _isDisposed = false;

        public UnitOfWork(ExpenseDBContext context)
        {
            _context = context;
        }
        public void Begin(IsolationLevel isolationLevel)
        {
            if(_context.Database.CurrentTransaction == null)
            {
                _transaction = _context.Database.BeginTransaction(isolationLevel);
            }
            else
            {
                _transaction = _context.Database.CurrentTransaction;
            }
        }

        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                _transaction.Commit();
                _transaction = _context.Database.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    try
                    {
                        if (_transaction != null)
                        {
                            try
                            {
                                _transaction.Rollback();
                                 _transaction.Dispose();
                            }
                            catch(Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Repositories
        private IExpenseTypeRepository _expenseType;
        public IExpenseTypeRepository ExpenseType => _expenseType ?? (_expenseType = new ExpenseTypeRepository(_context));

        private IExpenseRepository _expense;
        public IExpenseRepository Expense => _expense ?? (_expense = new ExpenseRepository(_context));
        #endregion
    }
}
