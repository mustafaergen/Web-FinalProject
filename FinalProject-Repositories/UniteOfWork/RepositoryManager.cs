using FinalProject_Repositories.Contexts;
using FinalProject_Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Repositories.UniteOfWork
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContex _contex;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContex contex, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _contex = contex;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public void Save()
        {
            _contex.SaveChanges();
        }
    }
}
