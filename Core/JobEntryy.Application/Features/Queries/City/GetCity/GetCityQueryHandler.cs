using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCity
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQueryRequest, GetCityQueryResponse>
    {
        private readonly ICityReadDapper cityReadDapper;
        private readonly ICityReadRepository cityReadRepository;
        public GetCityQueryHandler(ICityReadDapper cityReadDapper,ICityReadRepository cityReadRepository)
        {
            this.cityReadDapper = cityReadDapper;
            this.cityReadRepository = cityReadRepository;
        }

        public async Task<GetCityQueryResponse> Handle(GetCityQueryRequest request, CancellationToken cancellationToken)
        {
            //CityDto? city = await cityReadDapper.GetCity(request.Id);
            Domain.Entities.City? city = await cityReadRepository.GetFindAsync(request.Id);
            if (city == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            CityDto cityDto = city.Adapt<CityDto>();

            return new() { City = cityDto, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
