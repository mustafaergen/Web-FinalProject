using FinalProject_Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string? Name { get; set; } = string.Empty; //bişe verilmezse içerisi boş olmasını sağlarız.
        public virtual ICollection<Product>? Products { get; set; } // bir kategorinin birden fazla ürünü olabilir.
    }
}
