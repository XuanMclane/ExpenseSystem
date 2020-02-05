using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Invoice : BaseEntity
    {
        public DateTime InvoicedDate { get; set; }
        public string InvoicedNumber { get; set; }
        [Column(TypeName = "decimal(14,2)")]
        public decimal InvoicedAmount { get; set; }
        [Column(TypeName = "decimal(14,2)")]
        public decimal InvoicedTax { get; set; }
    }
}
