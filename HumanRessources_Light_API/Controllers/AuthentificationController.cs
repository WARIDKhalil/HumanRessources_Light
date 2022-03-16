using HumanRessources_Light_API.Requests;
using HumanRessources_Light_API.Responses;
using HumanRessources_Light_API.Services;
using HumanRessources_Light_API.Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanRessources_Light_API.Controllers
{
    /// <summary>
    ///     Handles authentification requests
    ///     Accessible for everyone
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthentificationController : Controller
    {
        private readonly AuthentificationService _service;
        public AuthentificationController(AuthentificationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IResponse> SignIn(SignInRequest request)
        {
            return await _service.SignIn(request);
        }
    }
}
