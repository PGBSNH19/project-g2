using KNet.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<CategoryModel> GetCategoryByName(string name);
    }
}