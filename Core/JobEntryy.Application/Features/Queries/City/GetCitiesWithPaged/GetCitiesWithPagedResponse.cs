using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.City.GetCitiesWithPaged
{
    public class GetCitiesWithPagedResponse
    {
        public Result Result { get; set; }
        public PaginatedResult<CityAllDto> Cities { get; set; }
    }
}