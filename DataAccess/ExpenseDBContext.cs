using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<int> SaveChangeAsync()
        {
            var createdRecords = ChangeTracker.Entries<BaseEntity>()
                .Where(t => t.State == EntityState.Added)
                .Select(t => t.Entity)
                .ToList();

            createdRecords.ForEach(record =>
            {
                record.CreationTimeStamp = DateTime.Now;
                record.CreatedBy = "Minxuan Zhang";
            });

            var updatedRecords = ChangeTracker.Entries<BaseEntity>()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity)
                .ToList();

            updatedRecords.ForEach(record =>
            {
                record.LastModificationTimeStamp = DateTime.Now;
                record.LastModifiedBy = "Minxuan Zhang";
            });

            ChangeTracker.DetectChanges();

            return await base.SaveChangesAsync();
        }
    }
}
