

using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Abstracts.Services.Dapper
{
    public interface ICityReadDapper
    {
        Task<List<CityDto>> GetCitiesWithCaching();
        Task<PaginatedResult<CityAllDto>> GetCitiesWithPaged(int pageNumber, int pageSize);
        Task<CityDto> GetCity(Guid id);
    }
}
