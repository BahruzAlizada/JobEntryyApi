using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommandRequest, CreateCityCommandResponse>
    {
        private readonly ICityWriteRepository cityWriteRepository;
        private readonly ICityRuleService cityRuleService;
        public CreateCityCommandHandler(ICityWriteRepository cityWriteRepository, ICityRuleService cityRuleService)
        {
            this.cityWriteRepository = cityWriteRepository;
            this.cityRuleService = cityRuleService;
        }


        public async Task<CreateCityCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(cityRuleService.CheckNameIfExist(request.Name));
            if (!result.Success) return new() { Result = result };

            Domain.Entities.City city = request.Adapt<Domain.Entities.City>();
            await cityWriteRepository.AddAndSaveAsync(city);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
