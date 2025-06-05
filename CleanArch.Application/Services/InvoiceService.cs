using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, IProductRepository productRepository)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<InvoiceViewModel>> GetAllAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            var invoiceVMs = _mapper.Map<IEnumerable<InvoiceViewModel>>(invoices);

            var products = await _productRepository.GetProducts();
            var productDict = products.ToDictionary(p => p.Id, p => p.Name);

            foreach (var invoice in invoiceVMs)
            {
                foreach (var item in invoice.InvoiceProducts)
                {
                    item.ProductName = productDict.TryGetValue(item.ProductId, out var name)
                        ? name
                        : $"Produto ID {item.ProductId}";
                }
            }

            return invoiceVMs;
        }
        

        public async Task<InvoiceViewModel> GetByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            var invoiceVM = _mapper.Map<InvoiceViewModel>(invoice);

            var products = await _productRepository.GetProducts();
            var productDict = products.ToDictionary(p => p.Id, p => p.Name);

            foreach (var item in invoiceVM.InvoiceProducts)
            {
                item.ProductName = productDict.TryGetValue(item.ProductId, out var name)
                    ? name
                    : $"Produto ID {item.ProductId}";
            }

            return invoiceVM;
        }

        public async Task<ServiceResultViewModel> CreateAsync(InvoiceViewModel model)
        {
            // Filtra produtos válidos
            model.InvoiceProducts = model.InvoiceProducts?
                .Where(p => p.IsSelected && p.Quantity > 0 && p.ProductId > 0)
                .ToList() ?? new List<InvoiceProductViewModel>();

            if (!model.InvoiceProducts.Any())
                return ServiceResultViewModel.Fail("Selecione pelo menos um produto com quantidade.");

            // Cálculo do total
            model.Total = model.InvoiceProducts.Sum(p => p.Quantity * p.Price);

            // Outras validações de negócio podem ser adicionadas aqui

            // Persistência
            var invoice = _mapper.Map<Invoice>(model);
            await _invoiceRepository.AddAsync(invoice);

            return ServiceResultViewModel.Ok();
        }

        public async Task DeleteAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null) return;

            await _invoiceRepository.DeleteAsync(invoice);
        }

    }
}
