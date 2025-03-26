using JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam;
using JobEntryy.Application.Features.Commands.JobSpam.DeleteJobSpam;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSpamsController : ControllerBase
    {
        private readonly IMediator mediator;
        public JobSpamsController(IMediator mediator)
        {
            this.mediator = mediator; 
        }


        #region CreateJobSpam
        [HttpPost("CreateJobSpam")]
        public async Task<IActionResult> CreateJobSpam([FromBody] CreateJobSpamCommandRequest request)
        {
            CreateJobSpamCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
        
        #region DeleteJobSpam
        [HttpDelete("DeleteJobSpam")]
        public async Task<IActionResult> DeleteJobSpam([FromQuery]DeleteJobSpamCommandRequest request)
        {
            DeleteJobSpamCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
