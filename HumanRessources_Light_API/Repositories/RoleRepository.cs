using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Repositories
{
    public class RoleRepository : MongoRepository<Role>
    {
        public RoleRepository(IDbContext dbContext) 
            : base(dbContext)
        {

        }

        /// <summary>
        ///     Get a role based on its name
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleByName(string rolename)
        {
            return await _collection.Find<Role>(_ => _.RoleName == rolename)
                                    .FirstOrDefaultAsync<Role>();
        } 

    }
}
