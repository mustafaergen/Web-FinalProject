using FinalProject_Entities.DTOs;
using FinalProject_Entities.Models;
using FinalProject_Services.Contracts;
using FinalProject_WebApp.Infrastructe.Extansions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalProject_WebApp.Pages
{
    public class ErrorModel2 : PageModel
    {
        private readonly IServiceManager _manager;

        public ErrorModel2(IServiceManager manager, Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }
        public void OnGet()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public Cart Cart { get; set; }
        public IActionResult OnPost(int Id)
        {
            ProductCreateDTO? product = _manager.ProductService.GetOneProductDTO(Id, false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return RedirectToPage("/Basket");
        }
        public IActionResult OnPostRemove(int id)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveItem(Cart.Lines.First(cl => cl.Product.Id == id).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}
