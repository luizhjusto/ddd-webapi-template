using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;
using Template.Api.ApplicationCore.Services;

namespace Template.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticate an user
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AuthorizationTokenDto), 200)]
        public async Task<IActionResult> AuthenticateAsync()
        {
            return Ok(await _authenticationService.AuthenticateAsync());
        }
    }
}