using System.Data.Common;
using System.Numerics;
using Dapper;
using JobEntryy.Application.Abstracts.Caching;
using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace JobEntryy.Persistence.Services.Dapper
{
    public class CategoryReadDapper : ICategoryReadDapper
    {
        private readonly DbConnection connection;
        private readonly ICacheService cacheService;
        public CategoryReadDapper(DbConnection connection, ICacheService cacheService)
        {
            this.connection = connection;
            this.cacheService = cacheService;
        }


        public async Task<List<CategoryAllDto>> GetAllCategories()
        {
            var query = "SELECT Id, Name, Status FROM Categories";
            var categories = await connection.QueryAsync<CategoryAllDto>(query);
            return categories.AsList();
        }

        public async Task<List<CategoryWithJobCountDto>> GetCachedCategoriesWithJobCount()
        {
            List<CategoryWithJobCountDto>? categories = cacheService.Get<List<CategoryWithJobCountDto>>(CacheKey.CategoriesWithJobCount);
            if(categories==null || !categories.Any())
            {
                var query = @"SELECT c.Id, c.Name, COUNT(j.Id) AS JobCount FROM Categories c LEFT JOIN Jobs j ON c.Id = j.CategoryId
            WHERE c.Status = 1 AND (j.Status = 1 OR j.Id IS NULL) GROUP BY c.Id, c.Name ORDER BY JobCount DESC";
                categories = (await connection.QueryAsync<CategoryWithJobCountDto>(query)).AsList();

                cacheService.Set(CacheKey.CategoriesWithJobCount, categories, 4, 12, CacheItemPriority.High);
            }
            return categories;
        }

        public async Task<List<CategoryDto>> GetCategoriesWithCaching()
        {
            List<CategoryDto>? categories = cacheService.Get<List<CategoryDto>>(CacheKey.Categories);
            if(categories == null || !categories.Any())
            {
                var query = "SELECT Id, Name FROM Categories WHERE Status=1";
                categories = (await connection.QueryAsync<CategoryDto>(query)).AsList();

                cacheService.Set(CacheKey.Categories, categories, 4, 12, CacheItemPriority.High);
            }
            return categories;
        }

        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var query = "SELECT Id, Name, Status FROM Categories WHERE Id=@Id";
            var category = await connection.QueryFirstOrDefaultAsync<CategoryDto>(query, new {Id=id});
            return category;
        }
    }
}
