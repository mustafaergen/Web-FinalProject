using FinalProject_Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; } = string.Empty; // database kısmında boş geçilebilir olacak ama fluent api kullanarak bunu düzeltilecek.
        public decimal Price { get; set; }
        public string? Summary { get; set; }
        public string? ImageUrl { get; set; } = "default.png";
        public int? CategoryId { get; set; }
        public bool ShowCase { get; set; } = true;
        public virtual Category? Category { get; set; }
    }
}
