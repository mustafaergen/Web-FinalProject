using Bogus;
using FinalProject_Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p=> p.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Summary).IsRequired(false);

            var products = new List<Product>
            {
                new Product { Id = 1, CategoryId = 1, Name = "Istanbul", Price = 35, ImageUrl = "default.png",ShowCase=true },
                new Product { Id = 2, CategoryId = 1, Name = "Fatih", Price = 35, ImageUrl = "default.png",ShowCase = true },
                new Product { Id = 3, CategoryId = 2, Name = "Asus Pc", Price = 35000, ImageUrl = "default.png", ShowCase = false },
                new Product { Id = 4, CategoryId = 2, Name = "Lenovo Pc", Price = 38000, ImageUrl = "default.png" ,ShowCase = true },
                new Product { Id = 5, CategoryId = 2, Name = "Mac Book", Price = 65000, ImageUrl = "default.png",ShowCase = true },
                new Product { Id = 6, CategoryId = 2, Name = "HP Pc", Price = 65000, ImageUrl = "default.png" ,ShowCase = false },
                new Product { Id = 7, CategoryId = 1, Name = "Roman", Price = 45, ImageUrl = "default.png" ,ShowCase = true },
                new Product { Id = 8, CategoryId = 3, Name = "Iphone 16 Pro Max", Price = 99000, ImageUrl = "default.png", ShowCase = false },
                new Product { Id = 9, CategoryId = 3, Name = "Iphone 15 Pro Max", Price = 85000, ImageUrl = "default.png",ShowCase = false },
                new Product { Id = 10, CategoryId = 3, Name = "Samsung", Price = 65000, ImageUrl = "default.png", ShowCase = true }
            };

            var productFaker = new Faker<Product>()
                .RuleFor(p => p.Id, f => products.Count + f.IndexFaker + 1)
                .RuleFor(p => p.CategoryId, f => f.Random.Int(1, 13))
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price(20, 100000)))
                .RuleFor(p => p.ImageUrl, f => "default.png")
                .RuleFor(p => p.ShowCase, f => f.Random.Bool());

            products.AddRange(productFaker.Generate(5));
            builder.HasData(products);
        }
    }
}
