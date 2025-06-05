using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceViewModel>> GetAllAsync();
        Task<InvoiceViewModel> GetByIdAsync(int id);
        Task<ServiceResultViewModel> CreateAsync(InvoiceViewModel invoiceViewModel);
        Task DeleteAsync(int id);
    }
}
