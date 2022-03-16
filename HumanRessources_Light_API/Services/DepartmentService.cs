using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;

namespace HumanRessources_Light_API.Services
{
    public class DepartmentService : GenericService<Department>
    {
        public DepartmentService(IRepository<Department> repository) 
            : base(repository)
        {

        }
    }
}
