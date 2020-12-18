using System;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    public interface IRepository
    {
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Delete<T>(Guid id) where T : class;
        Task<bool> Save();
        Task<T> Update<T>(T entity) where T : class;
    }
}
