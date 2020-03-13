using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DTO
{
    public class ExpenseDTO : BaseDTO
    {
        public DateTime ExpenseDate { get; set; }
        public long ExpenseTypeId { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal ExpenseAmount { get; set; }
        public decimal ExpenseTax { get; set; }
        public virtual ExpenseTypeDTO ExpenseType { get; set; }
    }
}
