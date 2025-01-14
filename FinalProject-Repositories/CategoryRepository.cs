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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContex context) : base(context)
        {
        }
    }
}
