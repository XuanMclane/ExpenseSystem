using DataAccess;
using Entity;
using ExpenseSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DataAccess.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ExpenseDBContext context) : base(context)
        {
        }
    }
}
