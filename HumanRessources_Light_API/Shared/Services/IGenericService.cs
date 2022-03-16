using HumanRessources_Light_API.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    /// <summary>
    ///     Basic CRUD services
    /// </summary>
    /// <typeparam name="T"> Model type</typeparam>
    public interface IGenericService<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsyncService(string Id);
        Task<List<T>> GetAllAsyncService();
        Task<T> AddAsyncService(T entity);
        Task<T> UpdateAsyncService(T entity);
        Task<bool> DeleteAsyncService(string Id);
    }
}
