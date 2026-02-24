using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Common.Interfaces;
using OnlineStore.WebApi.Common.Dtos.Auth;
namespace OnlineStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto loginRequest)
        {
            var login = await _identityService.LoginAsync(loginRequest.Email, loginRequest.Password);

            if (!login.IsSuccess)
            {
                return BadRequest(new { Error = login.Error });
            }
            return Ok(new { Token = login.Token });
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto registerRequest)
        {
            var register = await _identityService.RegisterAsync(registerRequest.Email, registerRequest.Password, registerRequest.FirstName, registerRequest.LastName);
            if (!register.IsSuccess)
            {
                return BadRequest(new { Error = register.Error });
            }
            return Ok(new { UserId = register.UserId });
        }
    }
}
