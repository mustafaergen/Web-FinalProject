using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.DTOs
{
    public record ProductDTO
    {
        public int Id { get; init; }
        [Required(ErrorMessage ="Isım Alanı Zorunludur!")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Fiyat Alanı Zorunludur!")]
        public decimal Price { get; init; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
        public bool ShowCase { get; init; }

    }
}
