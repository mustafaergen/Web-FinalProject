using FinalProject_Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_WebApp.Views.Shared.Components
{
    public class CardSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;
        public CardSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public string Invoke()
        {
           return _cart.Lines.Count.ToString();
        }
    }
}
