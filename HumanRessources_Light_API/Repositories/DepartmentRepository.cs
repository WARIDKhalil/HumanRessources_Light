using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;

namespace HumanRessources_Light_API.Repositories
{
    public class DepartmentRepository : MongoRepository<Department>
    {
        public DepartmentRepository(IDbContext dbContext) 
            : base(dbContext)
        {

        }
    }
}
