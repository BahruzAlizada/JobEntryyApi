using JobEntryy.Application.Features.Commands.City.CreateCity;
using JobEntryy.Application.Features.Commands.City.DeleteCity;
using JobEntryy.Application.Features.Commands.City.UpdateCity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region CreateCity
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommandRequest request)
        {
            CreateCityCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdateCity
        [HttpPut("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityCommandRequest request)
        {
            UpdateCityCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteCity
        [HttpDelete("DeleteCity")]
        public async Task<IActionResult> DeleteCity([FromQuery] DeleteCityCommandRequest request)
        {
            DeleteCityCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
