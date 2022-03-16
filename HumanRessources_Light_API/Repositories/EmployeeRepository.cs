using HumanRessources_Light_API.DbConfiguration;
using HumanRessources_Light_API.Models;

namespace HumanRessources_Light_API.Repositories
{
    public class EmployeeRepository : MongoRepository<Employee>
    {
        public EmployeeRepository(IDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
