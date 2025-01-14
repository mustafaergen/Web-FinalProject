using FinalProject_Entities.Enums;
using FinalProject_Repositories.Contracts.Base;
using FinalProject_Repositories.UniteOfWork;
using FinalProject_Services.Contracts;
using FinalProject_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _manager;

        public HomeController(ILogger<HomeController> logger, IServiceManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public IActionResult Index()
        {
           return View(_manager.ProductService.GetAllProdutsByShowCase(false));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
