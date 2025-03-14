using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.UpdateIndustry
{
    public class UpdateIndustryCommandHandler : IRequestHandler<UpdateIndustryCommandRequest, UpdateIndustryCommandResponse>
    {
        private readonly IIndustryWriteRepository industryWriteRepository;
        private readonly IIndustryRuleService industryRuleService;
        public UpdateIndustryCommandHandler(IIndustryWriteRepository industryWriteRepository, IIndustryRuleService industryRuleService)
        {
            this.industryWriteRepository = industryWriteRepository;
            this.industryRuleService = industryRuleService;
        }



        public async Task<UpdateIndustryCommandResponse> Handle(UpdateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(industryRuleService.CheckNameIfExist(request.Name, request.Id));
            if(!result.Success) return new() { Result = result };

            Domain.Entities.Industry industry = request.Adapt<Domain.Entities.Industry>();
            await industryWriteRepository.UpdateAndSaveAsync(industry);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
