using JobEntryy.Application.Features.Commands.Job.CreateJob;
using JobEntryy.Application.Features.Commands.Job.DeleteJob;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator mediator;
        public JobsController(IMediator mediator)
        {
            this.mediator = mediator;   
        }


        #region CreateJob
        [HttpPost("CreateJob")]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobCommandRequest request)
        {
            CreateJobCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteJob
        [HttpDelete("DeleteJob")]
        public async Task<IActionResult> DeleteJob([FromQuery] DeleteJobCommandRequest request)
        {
            DeleteJobCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
