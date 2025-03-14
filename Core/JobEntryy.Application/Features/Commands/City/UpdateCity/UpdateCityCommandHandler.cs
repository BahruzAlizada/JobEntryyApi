using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommandRequest, UpdateCityCommandResponse>
    {
        private readonly ICityWriteRepository cityWriteRepository;
        private readonly ICityRuleService cityRuleService;
        public UpdateCityCommandHandler(ICityWriteRepository cityWriteRepository, ICityRuleService cityRuleService)
        {
            this.cityWriteRepository = cityWriteRepository;
            this.cityRuleService = cityRuleService;
        }


        public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(cityRuleService.CheckNameIfExist(request.Name, request.Id));
            if(!result.Success) return new() { Result =  result };

            Domain.Entities.City city = request.Adapt<Domain.Entities.City>();
            await cityWriteRepository.UpdateAndSaveAsync(city);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
