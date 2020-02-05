using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ExpenseDBContext : DbContext
    {
        #region Tables
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
        #endregion

        public ExpenseDBContext(DbContextOptions<ExpenseDBContext> options) : base(options)
        {
        }
    }
}
