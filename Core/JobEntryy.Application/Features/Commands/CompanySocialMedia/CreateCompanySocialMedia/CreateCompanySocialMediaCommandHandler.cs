using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.CreateCompanySocialMedia
{
    public class CreateCompanySocialMediaCommandHandler : IRequestHandler<CreateCompanySocialMediaCommandRequest, CreateCompanySocialMediaCommandResponse>
    {
        private readonly ICompanySocialMediaWriteRepository companySocialMediaWriteRepository;
        private readonly ICompanySocialMediaRuleService companySocialMediaRuleService;
        public CreateCompanySocialMediaCommandHandler(ICompanySocialMediaWriteRepository companySocialMediaWriteRepository,ICompanySocialMediaRuleService companySocialMediaRuleService)
        {
            this.companySocialMediaWriteRepository = companySocialMediaWriteRepository;
            this.companySocialMediaRuleService = companySocialMediaRuleService;
        }



        public async Task<CreateCompanySocialMediaCommandResponse> Handle(CreateCompanySocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(await companySocialMediaRuleService.CheckCompany(request.CompanyId), companySocialMediaRuleService.CheckIfNameExisted(request.Platform));
            if(!result.Success) return new() { Result = result };

            Domain.Entities.CompanySocialMedia companySocialMedia = Domain.Entities.CompanySocialMedia.Create(request.CompanyId, request.Platform, request.Url);
            await companySocialMediaWriteRepository.AddAndSaveAsync(companySocialMedia);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
