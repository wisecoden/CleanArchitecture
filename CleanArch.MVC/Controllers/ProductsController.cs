using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {   
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductsController(IProductService productAppService, ICategoryService categoryService)
        {
            _productService = productAppService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {   
            var result = await _productService.GetProducts();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new MultiSelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {   
                _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            var categories = _categoryService.GetAllAsync().Result;
            ViewBag.Categories = new MultiSelectList(categories, "Id", "Name", product.CategoryIds);
            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id) 
        {

            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }


        [HttpPost()]
        public IActionResult Edit(ProductViewModel productVM)
        {
            if (ModelState.IsValid) {

                try 
                {
                    _productService.Update(productVM);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
                
            }

            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id) { 
            if(id == null) return NotFound();
            
            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);

        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        { 
            _productService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
