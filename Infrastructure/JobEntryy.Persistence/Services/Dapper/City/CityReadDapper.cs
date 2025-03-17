using System.Data.Common;
using Dapper;
using JobEntryy.Application.Abstracts.Caching;
using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using Microsoft.Extensions.Caching.Memory;

namespace JobEntryy.Persistence.Services.Dapper
{
    public class CityReadDapper : ICityReadDapper
    {
        private readonly DbConnection connection;
        private readonly ICacheService cacheService;
        public CityReadDapper(DbConnection connection, ICacheService cacheService)
        {
            this.connection = connection;
            this.cacheService = cacheService;
        }


        public async Task<List<CityDto>> GetCitiesWithCaching()
        {
            var cities = cacheService.Get<List<CityDto>>(CacheKey.Cities);
            if (cities == null || !cities.Any())
            {
                var query = "SELECT Id, Name FROM Cities WHERE Status = 1 ORDER BY Name";
                cities = (await connection.QueryAsync<CityDto>(query)).AsList();

                cacheService.Set<List<CityDto>>(CacheKey.Cities, cities, 4, 12, CacheItemPriority.High);
            }
            return cities;
        }

        public async Task<PaginatedResult<CityAllDto>> GetCitiesWithPaged(int pageNumber, int pageSize)
        {
            var totalCountQuery = "SELECT COUNT(*) FROM Cities";
            var totalCount = await connection.ExecuteScalarAsync<int>(totalCountQuery);

            var query = @"SELECT Id, Name, Status FROM Cities ORDER BY Name OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var cities = await connection.QueryAsync<CityAllDto>(query, new
            {
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            });

            return new PaginatedResult<CityAllDto>(cities.AsList(), totalCount, pageNumber, pageSize);
        }

        public async Task<CityDto> GetCity(Guid id)
        {
            var query = "SELECT Id, Name FROM Cities WHERE Id=@Id";
            var city = await connection.QueryFirstOrDefaultAsync<CityDto>(query, new { Id = id });
            return city;
        }
    }
}
