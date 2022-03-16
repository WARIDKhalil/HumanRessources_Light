using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Repositories
{
    /// <summary>
    ///     Contains base CRUD-methods
    /// </summary>
    public class MongoRepository<T> : IRepository<T> where T : IBaseEntity
    {
        // properties
        protected IMongoCollection<T> _collection;

        public MongoRepository(IDbContext dbContext)
        {
            _collection = (IMongoCollection<T>)dbContext.GetClassifier<T>(typeof(T).Name);
        }

        /// <summary>
        ///     Adding a new object into the collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        ///     the object inserted
        /// </returns>
        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        /// <summary>
        ///     Look for object and delete it
        ///     The object must exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        ///     Status
        /// </returns>
        public async Task<bool> DeleteAsync(string Id)
        {
            try
            {
                await _collection.DeleteOneAsync(_ => _.Id == Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        /// <summary>   
        ///     Get all documents of the collection
        /// </summary>
        /// <returns>
        ///     List of documents of type T
        /// </returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find<T>( _ => true).ToListAsync<T>();
        }

        /// <summary>
        ///     Get a specific document from a collection
        ///     Based on its Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        ///     Document of type T
        /// </returns>
        public async Task<T> GetByIdAsync(string Id)
        {
            return await _collection.Find<T>( _ => _.Id == Id).FirstOrDefaultAsync<T>();
        }

        /// <summary>
        ///     Update a whole specific document
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        ///     The updated document
        /// </returns>
        public async Task<T> UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync<T>( _ => _.Id == entity.Id, entity);
            return entity;
        }
    }
}
