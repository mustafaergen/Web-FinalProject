using AutoMapper;
using FinalProject_Entities.DTOs;
using FinalProject_Entities.Enums;
using FinalProject_Entities.Models;
using FinalProject_Repositories;
using FinalProject_Repositories.UniteOfWork;
using FinalProject_Services.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductCreateDTO product)
        {
            var pro = _mapper.Map<Product>(product);
            _manager.ProductRepository.Create(pro);
            _manager.Save();
        }

        public void DeleteOneProduct(int delete)
        {
            var pro = GetOneProduct(delete, true);
            if (pro != null)
            {
                _manager.ProductRepository.Delete(pro);
                _manager.Save();
            }
        }

        public IEnumerable<ProductDTO> GetAllProductDTOs(bool trackChanges, Status? status = null)
        {

            _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true));

            try
            {
                if (status is null)
                    //return _manager.ProductRepository.GettAllProducts(true).Select(x => new ProductDTO { Id = x.Id, Name = x.Name, CategoryId = x.CategoryId, ImageUrl = x.ImageUrl, Price = x.Price }).ToList();
                   return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true));
                else
                    //return _manager.ProductRepository.GettAllProducts(true).Where(x => x.Status == status).Select(x => new ProductDTO { Id = x.Id, Name = x.Name, CategoryId = x.CategoryId, ImageUrl = x.ImageUrl, Price = x.Price }).ToList();
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true).Where(x => x.Status == status));
            }
            catch 
            {

                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<ProductDTO> GetAllProductDTOsByCatId(bool trackChanges, int? CatId, Status? status = null)
        {
            
            try
            {
                if (status is null)
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true).Where(x => x.CategoryId == CatId));
                else
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true).Where(x => x.Status == status && x.CategoryId == CatId));
            }
            catch
            {

                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges, Status? status = null)
        {
            try
            {
                if (status is null)
                    return _manager.ProductRepository.GettAllProducts(true).ToList();
                else
                    return _manager.ProductRepository.GettAllProducts(true).Where(x => x.Status == status).ToList();
            }
            catch
            {

                throw new Exception("Ürünleri getirme aşamasında bir hata gerçekleşti");
            }
        }

        public IEnumerable<ProductDTO> GetAllProdutDTOsByOrderPrice(bool trackChanges, bool orderByAsc = true, Status? status = null)
        {
            try
            {
                if (orderByAsc)
                   return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true).OrderBy(x => x.Price));
                else
                    return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GettAllProducts(true).OrderByDescending(x => x.Price));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ProductDTO> GetAllProdutsByShowCase(bool trackChanges)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_manager.ProductRepository.GetAllProdutsByShowCase(false));
            
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
           return _manager.ProductRepository.GetOneProduct(id, trackChanges);
        }

        public ProductCreateDTO? GetOneProductDTO(int id, bool trackChanges)
        {
            return _mapper.Map<ProductCreateDTO>(_manager.ProductRepository.FindById(id, trackChanges));
        }

        public void UpdateOneProduct(ProductCreateDTO product)
        {
            
            var entity = _mapper.Map<Product>(product);
            _manager.ProductRepository.Update(entity);
            _manager.Save();

        }
    }
}
