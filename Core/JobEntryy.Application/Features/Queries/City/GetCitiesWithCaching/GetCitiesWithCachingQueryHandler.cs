using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCitiesWithCaching
{
    public class GetCitiesWithCachingQueryHandler : IRequestHandler<GetCitiesWithCachingQueryRequest, GetCitiesWithCachingQueryResponse>
    {
        private readonly ICityReadDapper cityReadDapper;
        public GetCitiesWithCachingQueryHandler(ICityReadDapper cityReadDapper)
        {
            this.cityReadDapper = cityReadDapper;
        }


        public async Task<GetCitiesWithCachingQueryResponse> Handle(GetCitiesWithCachingQueryRequest request, CancellationToken cancellationToken)
        {
            List<CityDto> cities = await cityReadDapper.GetCitiesWithCaching();
            return new() { Cities = cities, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
