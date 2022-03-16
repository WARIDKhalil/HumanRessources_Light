using HumanRessources_Light_API.Shared;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Repositories
{
    /// <summary>
    ///     Basic CRUD methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(string Id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);

    }
}
