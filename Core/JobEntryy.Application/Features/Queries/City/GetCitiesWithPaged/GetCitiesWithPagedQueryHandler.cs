using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCitiesWithPaged
{
    public class GetCitiesWithPagedQueryHandler : IRequestHandler<GetCitiesWithPagedRequest, GetCitiesWithPagedResponse>
    {
        private readonly ICityReadDapper cityReadDapper;
        public GetCitiesWithPagedQueryHandler(ICityReadDapper cityReadDapper)
        {
            this.cityReadDapper = cityReadDapper;
        }


        public async Task<GetCitiesWithPagedResponse> Handle(GetCitiesWithPagedRequest request, CancellationToken cancellationToken)
        {
            PaginatedResult<CityAllDto> cities = await cityReadDapper.GetCitiesWithPaged(request.PageNumber,request.PageSize);
            return new() { Cities = cities, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
