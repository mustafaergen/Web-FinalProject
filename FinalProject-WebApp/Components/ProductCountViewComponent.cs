using FinalProject_Entities.Enums;
using FinalProject_Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_WebApp.Components
{
    public class ProductCountViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductCountViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false,Status.Active).Count().ToString();
        }
    }
}
