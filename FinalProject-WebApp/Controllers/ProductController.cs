using FinalProject_Entities.DTOs;
using FinalProject_Entities.Enums;
using FinalProject_Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(int? CatId, [FromQuery] string? search )
        {
            var products = _manager.ProductService.GetAllProductDTOs(false, Status.Active);
            if (CatId != null)
                products = products.Where(x => x.CategoryId == CatId);
            if (search != null)
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            
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
