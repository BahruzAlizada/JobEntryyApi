using JobEntryy.Application.Features.Commands.City.CreateCity;
using JobEntryy.Application.Features.Commands.City.DeleteCity;
using JobEntryy.Application.Features.Commands.City.UpdateCity;
using JobEntryy.Application.Features.Queries.City.GetCitiesWithCaching;
using JobEntryy.Application.Features.Queries.City.GetCity;
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

        #region GetCitiesWithPaged
        [HttpGet("GetCitiesWithPaged")]
        public async Task<IActionResult> GetCitiesWithPaged([FromQuery] GetCitiesWithCachingQueryRequest request)
        {
            GetCitiesWithCachingQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region GetCitiesWithCaching
        [HttpGet("GetCitiesWithCaching")]
        public async Task<IActionResult> GetCitiesWithCaching()
        {
            GetCitiesWithCachingQueryResponse response = await mediator.Send(new GetCitiesWithCachingQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetCity
        [HttpGet("GetCity")]
        public async Task<IActionResult> GetCity([FromQuery] GetCityQueryRequest request)
        {
            GetCityQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

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
