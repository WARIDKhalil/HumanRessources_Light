using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Services
{
    public class RoleService : GenericService<Role>
    {

        public RoleService(IRepository<Role> repository) : 
            base(repository)
        {
            
        }

        /// <summary>
        ///     Getting a role by its name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>the target role</returns>
        public async Task<Role> GetRoleByNameService(string roleName)
        {
            return await ((RoleRepository)_repository).GetRoleByName(roleName);
        }

    }
}
