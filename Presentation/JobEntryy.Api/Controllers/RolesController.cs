using JobEntryy.Application.Features.Commands.AppRole.CreateRole;
using JobEntryy.Application.Features.Commands.AppRole.DeleteRole;
using JobEntryy.Application.Features.Commands.AppRole.UpdateRole;
using JobEntryy.Application.Features.Queries.AppRole.GetRole;
using JobEntryy.Application.Features.Queries.AppRole.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator mediator;
        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetRoles
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            GetRolesQueryResponse response = await mediator.Send(new GetRolesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetRole
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole([FromQuery] GetRoleQueryRequest request)
        {
            GetRoleQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region CreateRole
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest request)
        {
            CreateRoleCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdateRole
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest request)
        {
            UpdateRoleCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteRole
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommandRequest request)
        {
            DeleteRoleCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
