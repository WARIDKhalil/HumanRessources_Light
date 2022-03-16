using MongoDB.Driver;

namespace HumanRessources_Light_API.DbConfiguration
{
    /// <summary>
    ///     Shared method(s) among DbContext classes
    /// </summary>
    public interface IDbContext
    {
        object GetClassifier<T>(string collectionName);
    }
}
