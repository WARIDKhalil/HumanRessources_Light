using HumanRessources_Light_API.Requests;
using HumanRessources_Light_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Controllers
{
    /// <summary>
    ///     Handles registration requests
    ///     Accessible for everyone
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {

        private readonly RegistrationService _service;
        public RegistrationController(RegistrationService service)
        {
            _service = service;
        }

        [HttpPost("Administrator")]
        public async Task<bool> RegisterAdministrator(SignUpRequest request)
        {
            return await _service.RegisterAdministratorService(request);
        }

        [HttpPost("Employee")]
        public async Task<bool> RegisterEmployee(SignUpRequest request)
        {
            return await _service.RegisterEmployeeService(request);
        }

    }
}
