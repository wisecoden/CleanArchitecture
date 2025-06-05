using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Infra.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CleanArch.MVC.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;

        public InvoiceController(IInvoiceService invoiceService, IProductService productService, UserManager<ApplicationUser> userManager)
        {
            _invoiceService = invoiceService;
            _productService = productService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceService.GetAllAsync();
            var products = await _productService.GetProducts();
            ViewBag.Products = products.ToList(); // Garantir conversão para List<>
            return View(invoices);
        }
        // Exibe o formulário de compra com a lista de produtos disponíveis

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetProducts();
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _invoiceService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        // Recebe os dados do formulário e cria a venda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceViewModel model)
        {
            // Filtra produtos válidos (produto selecionado, com quantidade > 0 e ID válido)
           

            // Se houver erros de validação de modelo (ex: campos obrigatórios)
            if (!ModelState.IsValid)
            {
                ViewBag.Products = await _productService.GetProducts();
                return View(model);
            }

            // Preenche campos automáticos
            var user = await _userManager.GetUserAsync(User);
            model.UserId = user?.Id;
            model.CreatedAt = DateTime.Now;

            // Persiste a venda
         
            try
            {
                var result = await _invoiceService.CreateAsync(model);
                

                if (!result.Success)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    ViewBag.Products = await _productService.GetProducts();
                    return View(model);
                }
                // ...
            }
            catch (Exception ex)
            {
                // Log e mensagem amigável
                ModelState.AddModelError("", "Ocorreu um erro inesperado.");
                // ...
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
