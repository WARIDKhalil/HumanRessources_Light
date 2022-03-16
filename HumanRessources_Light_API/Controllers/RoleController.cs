using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : GenericCRUDController<Role>
    {
        public RoleController(IGenericService<Role> service)
            : base(service)
        {
           
        }
 
    }
}
