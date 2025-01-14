using FinalProject_Entities.Models;
using FinalProject_Repositories.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories.Contexts
{
    public class RepositoryContex : DbContext
    {
        //Options Patern mvcye yüklenecek 
        //büyük projelerde farklı contexler olabilir o yüzden sadece RepositoryContex 
        public RepositoryContex(DbContextOptions<RepositoryContex> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //FluentApi kalabalık olmaması için config dosyası oluşturulur 
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            //modelBuilder.ApplyConfiguration(new ProductConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
