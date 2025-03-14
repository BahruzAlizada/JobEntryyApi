using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.UpdateExperience
{
    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommandRequest, UpdateExperienceCommandResponse>
    {
        private readonly IExperienceWriteRepository experienceWriteRepository;
        private readonly IExperienceRuleService experienceRuleService;
        public UpdateExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository, IExperienceRuleService experienceRuleService)
        {
            this.experienceWriteRepository = experienceWriteRepository;
            this.experienceRuleService = experienceRuleService;
        }


        public async Task<UpdateExperienceCommandResponse> Handle(UpdateExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(experienceRuleService.CheckNameIfExist(request.Name, request.Id));
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Experience experience = request.Adapt<Domain.Entities.Experience>();
            await experienceWriteRepository.UpdateAndSaveAsync(experience);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
