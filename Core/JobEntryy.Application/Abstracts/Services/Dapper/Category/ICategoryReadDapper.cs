using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts.Services.Dapper
{
    public interface ICategoryReadDapper
    {
        Task<List<CategoryAllDto>> GetAllCategories();
        Task<List<CategoryDto>> GetCategoriesWithCaching();
        Task<CategoryDto> GetCategory(Guid id);
        Task<List<CategoryWithJobCountDto>> GetCachedCategoriesWithJobCount();
    }
}
