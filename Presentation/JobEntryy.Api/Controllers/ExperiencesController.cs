using JobEntryy.Application.Features.Commands.Experience.CreateExperience;
using JobEntryy.Application.Features.Commands.Experience.DeleteExperience;
using JobEntryy.Application.Features.Commands.Experience.UpdateExperience;
using JobEntryy.Application.Features.Queries.Experience.GetAllExperiences;
using JobEntryy.Application.Features.Queries.Experience.GetExperience;
using JobEntryy.Application.Features.Queries.Experience.GetExperiences;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ExperiencesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetAllExperiences
        [HttpGet("GetAllExperiences")]
        public async Task<IActionResult> GetAllExperiences()
        {
            GetAllExperiencesQueryResponse response = await mediator.Send(new GetAllExperiencesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetExperiences
        [HttpGet("GetExperiences")]
        public async Task<IActionResult> GetExperiences()
        {
            GetExperiencesQueryResponse response = await mediator.Send(new GetExperiencesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetExperience
        [HttpGet("GetExperience")]
        public async Task<IActionResult> GetExperience([FromQuery] GetExperienceQueryRequest request)
        {
            GetExperienceQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region CreateExperience
        [HttpPost("CreateExperience")]
        public async Task<IActionResult> CreateExperience([FromBody] CreateExperienceCommandRequest request)
        {
            CreateExperienceCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdateExperience
        [HttpPut("UpdateExperience")]
        public async Task<IActionResult> UpdateExperience([FromBody] UpdateExperienceCommandRequest request)
        {
            UpdateExperienceCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteExperience
        [HttpDelete("DeleteExperience")]
        public async Task<IActionResult> DeleteExperience([FromQuery] DeleteExperienceCommandRequest request)
        {
            DeleteExperienceCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
