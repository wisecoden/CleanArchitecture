using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string UserId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
