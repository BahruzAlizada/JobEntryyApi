using JobEntryy.Application.Features.Commands.AppUser.Login;
using JobEntryy.Application.Features.Commands.AppUser.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            LoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            RegisterCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
