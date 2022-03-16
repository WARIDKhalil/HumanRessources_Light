using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;

namespace HumanRessources_Light_API.Services
{
    public class EmployeeService : GenericService<Employee>
    {
        public EmployeeService(IRepository<Employee> repository) 
            : base(repository)
        {

        }
    }
}
