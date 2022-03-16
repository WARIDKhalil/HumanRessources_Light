using HumanRessources_Light_API.Services;
using HumanRessources_Light_API.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Controllers
{
    /// <summary>
    ///     A generic controller for main operations: 
    ///     Create Retreive Update Delete
    ///     Methods can be overrided in sub-controllers
    /// </summary>
    /// <typeparam name="T">Model Type</typeparam>
    public class GenericCRUDController<T> : Controller where T : IBaseEntity
    {
        protected IGenericService<T> _service;

        /// <summary>
        ///     Injection of target service
        /// </summary>
        /// <param name="service"></param>
        public GenericCRUDController(IGenericService<T> service)
        {
            _service = service;
        }

        /// <summary>
        ///     Retereive all entities using the service
        /// </summary>
        /// <returns>
        ///     List<T> of entities 
        /// </returns>
        [HttpGet]
        public virtual async Task<List<T>> GetAll()
        {
            return await _service.GetAllAsyncService();
        }

        /// <summary>
        ///     Retreive a specific entity using the service
        /// </summary>
        /// <param name="Id">/[ControllerName]/Id</param>
        /// <returns>
        ///     Entity of type T
        /// </returns>
        [HttpGet("{Id}")]
        public virtual async Task<T> GetOneById(string Id)
        {
            return await _service.GetByIdAsyncService(Id);
        }

        /// <summary>
        ///     Add a new entity using the service
        /// </summary>
        /// <param name="entity">From body</param>
        /// <returns>
        ///     The created entity
        /// </returns>
        [HttpPost]
        public virtual async Task<T> AddOne(T entity)
        {
            return await _service.AddAsyncService(entity);
        }

        /// <summary>
        ///     Delete an entity using the service
        /// </summary>
        /// <param name="Id">/[ControllerName]/Id</param>
        /// <returns>
        ///     true : success
        ///     false : error
        /// </returns>
        [HttpDelete("{Id}")]
        public virtual async Task<bool> DeleteOne(string Id)
        {
            return await _service.DeleteAsyncService(Id);
        }

        /// <summary>
        ///     Update an entity using the service
        /// </summary>
        /// <param name="entity">From Body, including the Id</param>
        /// <returns>
        ///     Updated entity
        /// </returns>
        [HttpPut]
        public virtual async Task<T> UpdateOne(T entity)
        {
            return await _service.UpdateAsyncService(entity);
        }

    }
}
