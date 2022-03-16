using HumanRessources_Light_API.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.DbConfiguration
{
    public class MongoDbContext : IDbContext
    {
        /// <summary>
        ///     reference to the database
        /// </summary>
        private IMongoDatabase Database { get; set; }
        /// <summary>
        ///     The session holder
        /// </summary>
        private MongoClient Client { get; set; }

        public MongoDbContext(IOptions<DbSettings> settings)
        {
            Client = new MongoClient(settings.Value.ConnectionString);
            Database = Client.GetDatabase(settings.Value.DatabaseName);
        }

        /// <summary>
        ///     Get a collection based on its name from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns>
        ///     Collection of type T
        /// </returns>
        public object GetClassifier<T>(string collectionName)
        {
            if (!CollectionExists(Database, collectionName))
                Database.CreateCollection(collectionName);
            return Database.GetCollection<T>(collectionName);
        }

        /// <summary>
        ///  Check if a collection already exists
        /// </summary>
        /// <param name="database"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };
            return database.ListCollectionNames(options).Any();
        }


    }
}
