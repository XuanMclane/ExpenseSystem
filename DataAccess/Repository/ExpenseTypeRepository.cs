using DataAccess;
using Entity;
using ExpenseSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DataAccess.Repository
{
    public class ExpenseTypeRepository : Repository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(ExpenseDBContext context) : base(context)
        {
        }
    }
}
