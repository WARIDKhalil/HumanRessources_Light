using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanRessources_Light_API.Controllers
{
    /// <summary>
    ///  Requires an authentification to be used
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : GenericCRUDController<Employee>
    {
        public EmployeeController(IGenericService<Employee> service) 
            : base(service)
        {

        }
    }
}
