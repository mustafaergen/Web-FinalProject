using FinalProject_Entities.DTOs;
using FinalProject_Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FinalProject_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.ProductService.GetAllProducts(true).OrderByDescending(x => x.CreatedDate));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDTO model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //File Operation 
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                model.ImageUrl = file.FileName;
                _manager.ProductService.CreateOneProduct(model);
                TempData["Success"] = $"{model.Name} İsimli Ürün Eklendi.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductDTO(id,true);
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(ProductCreateDTO model, IFormFile? file)
        {
            
                if(file is not null)
                {
                    //File Operation 
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.ImageUrl = file.FileName;
                }
                _manager.ProductService.UpdateOneProduct(model);
                TempData["Success"] = $"{model.Name} İsimli Ürün Başarılı Bir Şekilde Güncellenmiştir. .";
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetCategories(true),"Id","Name");
        }

    }
}
