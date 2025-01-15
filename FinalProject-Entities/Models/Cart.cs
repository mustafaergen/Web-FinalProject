using FinalProject_Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.Models
{
    public class Cart
    {
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public  List<CartLine> Lines { get; set; }
        public void AddItem(ProductCreateDTO product, int quantity)
        {
            CartLine line = Lines.Where(l => l.Product.Id == product.Id).FirstOrDefault();
            if(line is null)
            {
                Lines.Add(new CartLine() { Product = product, Quantity = quantity });

            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(ProductCreateDTO product )
        {
            Lines.RemoveAll(l => l.Product.Id == product.Id);
        }
        public void Clear() => Lines.Clear();
        public decimal TotalPrice() => Lines.Sum(l => l.Product.Price * l.Quantity);

    }
}
