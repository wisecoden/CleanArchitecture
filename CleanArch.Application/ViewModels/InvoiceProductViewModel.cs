using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class InvoiceProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public bool IsSelected { get; set; }

        public string? ProductName { get; set; }
    }
}
