using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Repositories
{
    public class AccountRepository : MongoRepository<Account>
    {
        public AccountRepository(IDbContext dbContext) 
            : base(dbContext)
        {

        }

        /// <summary>
        ///   Get an account based on login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByLogin(string login)
        {
            return await _collection.Find<Account>(_ => _.Login == login)
                                    .FirstOrDefaultAsync<Account>();
        }
    }
}
