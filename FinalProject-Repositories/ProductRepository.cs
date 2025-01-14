using FinalProject_Entities.Models;
using FinalProject_Repositories.Contexts;
using FinalProject_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(RepositoryContex context) : base(context)
        {
        }

        public void CreateOneProduc(Product product) => Create(product);

        public void DeleteOneProduc(Product product) => Delete(product);

        public IQueryable<Product> GetAllProdutsByOrderPrice(bool trackChanges, bool orderByAsc = true)
        {
            return orderByAsc
                 ? _context.Products.OrderBy(x => x.Price)
                 : _context.Products.OrderByDescending(x => x.Price);
        }

        public IQueryable<Product> GetAllProdutsByShowCase(bool trackChanges)
        {
            return FindAllCondation(x=>x.ShowCase== true, trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges) => FindById(id, trackChanges);

        public IQueryable<Product> GettAllProducts(bool trackChanges) => FindAll(trackChanges);

        public void UpdateOneProduc(Product product) => Update(product);
    }
}
