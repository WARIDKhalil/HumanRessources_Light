using HumanRessources_Light_API.Repositories;
using HumanRessources_Light_API.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    /// <summary>
    ///     Basic implementation for essentials services
    ///     methods can be overrided in sub-services
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    public class GenericService<T> : IGenericService<T> where T : IBaseEntity
    {
        /// <summary>
        ///     holder of a pre-implemented repository
        /// </summary>
        protected IRepository<T> _repository;

        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }


        public virtual async Task<T> AddAsyncService(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<bool> DeleteAsyncService(string Id)
        {
            return await _repository.DeleteAsync(Id);
        }

        public virtual Task<List<T>> GetAllAsyncService()
        {
            return _repository.GetAllAsync();
        }

        public virtual Task<T> GetByIdAsyncService(string Id)
        {
            return _repository.GetByIdAsync(Id);
        }

        public virtual async Task<T> UpdateAsyncService(T entity)
        {
            return await _repository.UpdateAsync(entity); 
        }

    }
}
