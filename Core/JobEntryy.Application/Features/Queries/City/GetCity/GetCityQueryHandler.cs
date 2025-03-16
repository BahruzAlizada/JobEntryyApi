using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCity
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQueryRequest, GetCityQueryResponse>
    {
        private readonly ICityReadDapper cityReadDapper;
        public GetCityQueryHandler(ICityReadDapper cityReadDapper)
        {
            this.cityReadDapper = cityReadDapper;
        }

        public async Task<GetCityQueryResponse> Handle(GetCityQueryRequest request, CancellationToken cancellationToken)
        {
            CityDto? city = await cityReadDapper.GetCity(request.Id);
            if (city == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            return new() { City = city, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
