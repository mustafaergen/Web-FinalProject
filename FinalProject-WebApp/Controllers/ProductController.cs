using FinalProject_Entities.DTOs;
using FinalProject_Entities.Enums;
using FinalProject_Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IServiceManager manager, ILogger<ProductController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public IActionResult Index(int? CatId, [FromQuery] string? search )
        {
            _logger.LogInformation("Ürünler Listleniyor");
            var stopwatch = Stopwatch.StartNew();
           
            var products = _manager.ProductService.GetAllProductDTOs(false, Status.Active);
            if (CatId != null)
                products = products.Where(x => x.CategoryId == CatId);
            if (search != null)
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            stopwatch.Stop();
            _logger.LogInformation($"Fetched {products.Count()} products in {stopwatch.ElapsedMilliseconds}ms. - In Product Home Page");
            return View(products);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _manager.ProductService.GetOneProductDTO(id, false);
            if (model is not null)
                return View(model);
            return RedirectToPage("/Error");
        }
    }
}
