using JobEntryy.Application.Features.Commands.Industry.CreateIndustry;
using JobEntryy.Application.Features.Commands.Industry.DeleteIndustry;
using JobEntryy.Application.Features.Commands.Industry.UpdateIndustry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public IndustriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region CreateIndustry
        [HttpPost("CreateIndustry")]
        public async Task<IActionResult> CreateIndustry([FromBody] CreateIndustryCommandRequest request)
        {
            CreateIndustryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdateIndustry
        [HttpPut("UpdateIndustry")]
        public async Task<IActionResult> UpdateIndustry([FromBody] UpdateIndustryCommandRequest request)
        {
            UpdateIndustryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteIndustry
        [HttpDelete("DeleteIndustry")]
        public async Task<IActionResult> DeleteIndustry([FromQuery] DeleteIndustryCommandRequest request)
        {
            DeleteIndustryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
