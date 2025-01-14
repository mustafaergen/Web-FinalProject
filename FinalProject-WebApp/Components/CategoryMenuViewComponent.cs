using FinalProject_Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_WebApp.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke()
        {
            var deneme = _manager.CategoryService.GetCategoriesWithCount();
            var categories = _manager.CategoryService.GetCategories(true);

            return View(deneme);
        }
    }
}
