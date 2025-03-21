using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Features.Commands.Category.CreateCategory;
using JobEntryy.Application.Features.Commands.Category.DeleteCategory;
using JobEntryy.Application.Features.Commands.Category.UpdateCategory;
using JobEntryy.Application.Features.Queries.Category.GetAllCategories;
using JobEntryy.Application.Features.Queries.Category.GetCachedCategoriesWithJobCount;
using JobEntryy.Application.Features.Queries.Category.GetCategoriesWithCaching;
using JobEntryy.Application.Features.Queries.Category.GetCategory;
using JobEntryy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        #region GetAllCategories
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            GetAllCategoriesQueryResponse response = await mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetCachedCategoriesWithJobCount
        [HttpGet("GetCachedCategoriesWithJobCount")]
        public async Task<IActionResult> GetCachedCategoriesWithJobCount()
        {
            GetCachedCategoriesWithJobCountQueryResponse response = await mediator.Send(new GetCachedCategoriesWithJobCountQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetCategoriesWithCaching
        [HttpGet("GetCategoriesWithCaching")]
        public async Task<IActionResult> GetCategoriesWithCaching()
        {
            GetCategoriesWithCachingQueryResponse response = await mediator.Send(new GetCategoriesWithCachingQueryRequest());
            return Ok(response);
        }
        #endregion

        #region GetCategory
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryQueryRequest request)
        {
            GetCategoryQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        #endregion

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
