using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.UpdateCompanySocialMedia
{
    public class UpdateCompanySocialMediaCommandHandler : IRequestHandler<UpdateCompanySocialMediaCommandRequest, UpdateCompanySocialMediaCommandResponse>
    {
        private readonly ICompanySocialMediaWriteRepository companySocialMediaWriteRepository;
        private readonly ICompanySocialMediaRuleService companySocialMediaRuleService;
        public UpdateCompanySocialMediaCommandHandler(ICompanySocialMediaWriteRepository companySocialMediaWriteRepository, ICompanySocialMediaRuleService companySocialMediaRuleService)
        {
            this.companySocialMediaWriteRepository = companySocialMediaWriteRepository;
            this.companySocialMediaRuleService = companySocialMediaRuleService;
        }


        public async Task<UpdateCompanySocialMediaCommandResponse> Handle(UpdateCompanySocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(await companySocialMediaRuleService.CheckCompany(request.CompanyId), companySocialMediaRuleService.CheckIfNameExisted(request.Platform, request.Id));
            if(!result.Success) return new() { Result = result };

            Domain.Entities.CompanySocialMedia companySocialMedia = request.Adapt<Domain.Entities.CompanySocialMedia>();
            await companySocialMediaWriteRepository.UpdateAndSaveAsync(companySocialMedia);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
