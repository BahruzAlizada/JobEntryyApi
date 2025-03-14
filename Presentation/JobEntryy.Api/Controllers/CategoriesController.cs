using JobEntryy.Application.Features.Commands.Category.CreateCategory;
using JobEntryy.Application.Features.Commands.Category.DeleteCategory;
using JobEntryy.Application.Features.Commands.Category.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobEntryy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region CreateCategory
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region UpdateCategory
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region DeleteCategory
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommandRequest request)
        {
            DeleteCategoryCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
