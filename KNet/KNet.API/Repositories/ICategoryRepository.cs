using KNet.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<CategoryModel> GetCategoryById(Guid id);
        Task<IList<CategoryModel>> GetAllCategories();
        Task<CategoryModel> GetCategoryByName(string name);
    }
}