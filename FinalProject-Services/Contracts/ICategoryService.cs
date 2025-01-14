using FinalProject_Entities.DTOs;
using FinalProject_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Services.Contracts
{
    public interface ICategoryService 
    {
        IEnumerable<Category> GetCategories(bool trackChanges);
        IEnumerable<CategoryWithCountDTO> GetCategoriesWithCount();
        CategoryDTO GetCategoryDTOById(int id);
        void CreateCategory(string categoryName);
        void UpdateCategory(CategoryDTO category);
        void DeleteCategory(int id);
    }
}
