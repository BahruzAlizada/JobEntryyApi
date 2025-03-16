using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.City.GetCitiesWithCaching
{
    public class GetCitiesWithCachingQueryResponse
    {
        public Result Result { get; set; }
        public List<CityDto> Cities { get; set; }
    }
}