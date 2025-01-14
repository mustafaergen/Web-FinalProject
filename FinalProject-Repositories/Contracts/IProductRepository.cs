using FinalProject_Entities.Models;
using FinalProject_Repositories.Contracts.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GettAllProducts(bool trackChanges);
        IQueryable<Product> GetAllProdutsByOrderPrice(bool trackChanges, bool orderByAsc=true);
        IQueryable<Product> GetAllProdutsByShowCase(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduc(Product product);
        void UpdateOneProduc(Product product);
        void DeleteOneProduc(Product product);

    }
}
