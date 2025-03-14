using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.CreateIndustry
{
    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommandRequest, CreateIndustryCommandResponse>
    {
        private readonly IIndustryWriteRepository industryWriteRepository;
        private readonly IIndustryRuleService industryRuleService;
        public CreateIndustryCommandHandler(IIndustryWriteRepository industryWriteRepository, IIndustryRuleService industryRuleService)
        {
            this.industryWriteRepository = industryWriteRepository;
            this.industryRuleService = industryRuleService;
        }


        public async Task<CreateIndustryCommandResponse> Handle(CreateIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(industryRuleService.CheckNameIfExist(request.Name));
            if(!result.Success) return new() { Result = result };

            Domain.Entities.Industry industry = request.Adapt<Domain.Entities.Industry>();
            await industryWriteRepository.AddAndSaveAsync(industry);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
