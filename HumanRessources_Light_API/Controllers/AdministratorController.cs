using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Controllers
{
    /// <summary>
    ///  Only accessible by Authenticated Administrators
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : GenericCRUDController<Administrator>
    {
        public AdministratorController(IGenericService<Administrator> service) 
            : base(service)
        {

        }

    }
}
