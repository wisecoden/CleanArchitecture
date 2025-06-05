using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        
        public string? UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        [Required]
        public List<InvoiceProductViewModel> InvoiceProducts { get; set; }
    }
}
