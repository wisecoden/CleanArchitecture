using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace CleanArch.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int id);
        Task AddAsync(Invoice invoice);

        Task DeleteAsync(Invoice invoice);

    }
}
