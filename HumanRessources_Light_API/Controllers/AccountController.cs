using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanRessources_Light_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class AccountController : GenericCRUDController<Account>
    {
        public AccountController(IGenericService<Account> service) 
            : base(service)
        {

        }
    }
}
