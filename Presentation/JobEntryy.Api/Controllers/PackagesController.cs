using JobEntryy.Application.Features.Commands.Package.CreatePackage;
using JobEntryy.Application.Features.Commands.Package.DeletePackage;
using JobEntryy.Application.Features.Commands.Package.UpdatePackage;
using JobEntryy.Application.Features.Queries.Package.GetAllPackages;
using JobEntryy.Application.Features.Queries.Package.GetPackage;
using JobEntryy.Application.Features.Queries.Package.GetPackages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IMediator mediator;
        public PackagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetAllPackages
        [HttpGet("GetAllPackages")]
        public async Task<IActionResult> GetAllPackages()
        {
            GetAllPackagesQueryResponse response = await mediator.Send(new GetAllPackagesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetPackages
        [HttpGet("GetPackages")]
        public async Task<IActionResult> GetPackages()
        {
            GetPackagesQueryResponse response = await mediator.Send(new GetPackagesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetPackage
        [HttpGet("GetPackage")]
        public async Task<IActionResult> GetPackage([FromQuery] GetPackageQueryRequest request)
        {
            GetPackageQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region CreatePackage
        [HttpPost("CreatePackage")]
        public async Task<IActionResult> CreatePackage([FromBody] CreatePackageCommandRequest request)
        {
            CreatePackageCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdatePackage
        [HttpPut("UpdatePackage")]
        public async Task<IActionResult> UpdatePackage([FromBody] UpdatePackageCommandRequest request)
        {
            UpdatePackageCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeletePackage
        [HttpDelete("DeletePackage")]
        public async Task<IActionResult> DeletePackage([FromQuery] DeletePackageCommandRequest request)
        {
            DeletePackageCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
