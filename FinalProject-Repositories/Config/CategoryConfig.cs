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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
            builder.HasMany(c => c.Products).WithOne(c => c.Category).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Book" },
                new Category { Id = 2, Name = "Computer" },
                new Category { Id = 3, Name = "Phone" }
            };

            var faker = new Faker<Category>()
                .RuleFor(c => c.Id, f => categories.Count + f.IndexFaker + 1) // ıd otomotik artar.
                .RuleFor(c => c.Name, f => f.Commerce.Department());
            categories.AddRange(faker.Generate(5));
            builder.HasData(categories);
        }
    }
}
