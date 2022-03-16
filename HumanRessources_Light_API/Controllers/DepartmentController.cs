using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanRessources_Light_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : GenericCRUDController<Department>
    {
        public DepartmentController(IGenericService<Department> service) 
            : base(service)
        {

        }
    }
}
