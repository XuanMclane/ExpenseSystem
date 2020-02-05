using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Expense : BaseEntity
    {
        public DateTime ExpenseDate { get; set; }
        [ForeignKey(nameof(ExpenseType))]
        public long ExpenseTypeId { get; set; }
        public string ExpenseDescription { get; set; }
        [Column(TypeName = "decimal(14,2)")]
        public decimal ExpenseAmount { get; set; }
        [Column(TypeName = "decimal(14,2)")]
        public decimal ExpenseTax { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
