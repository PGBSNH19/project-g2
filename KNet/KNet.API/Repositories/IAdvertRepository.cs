using KNet.API.Models;
using System;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface IAdvertRepository : IRepository
    {
        Task<Advert> GetAdvertById(Guid id);
    }
}