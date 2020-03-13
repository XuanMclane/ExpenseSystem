using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.DTO
{
    public class InvoiceDTO : BaseDTO
    {
        public DateTime InvoicedDate { get; set; }
        public string InvoicedNumber { get; set; }
        public decimal InvoicedAmount { get; set; }
        public decimal InvoicedTax { get; set; }
    }
}
