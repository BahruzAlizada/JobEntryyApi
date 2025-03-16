using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.City.GetCity
{
    public class GetCityQueryResponse
    {
        public Result? Result { get; set; }
        public CityDto? City { get; set; }
    }
}