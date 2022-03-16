using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;

namespace HumanRessources_Light_API.Repositories
{
    public class AdministratorRepository : MongoRepository<Administrator>
    {
        public AdministratorRepository(IDbContext dbContext) 
            : base(dbContext)
        {

        }
    }
}
