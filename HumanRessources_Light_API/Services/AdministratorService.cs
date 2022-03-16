using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;

namespace HumanRessources_Light_API.Services
{
    public class AdministratorService : GenericService<Administrator>
    {
        public AdministratorService(IRepository<Administrator> repository) 
            : base(repository)
        {

        }
    }
}
