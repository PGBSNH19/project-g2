using KNet.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface IAdvertRepository : IRepository
    {
        Task<AdvertModel> GetAdvertById(Guid id);
        Task<IList<AdvertModel>> GetAllAdverts();
        Task<IList<AdvertModel>> GetUserBookmarks(Guid id);
    }
}