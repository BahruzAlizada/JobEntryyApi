using JobEntryy.Application.Features.Commands.AppUser.AssignRolesToUser;
using JobEntryy.Application.Features.Queries.AppUser.GetUser;
using JobEntryy.Application.Features.Queries.AppUser.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetUsers
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            GetUsersQueryResponse response = await mediator.Send(new GetUsersQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetUser
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQueryRequest request)
        {
            GetUserQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region AssingRolesToUser
        [HttpPost("AssignRolesToUser")]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AssignRolesToUserCommandRequest request )
        {
            AssignRolesToUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
