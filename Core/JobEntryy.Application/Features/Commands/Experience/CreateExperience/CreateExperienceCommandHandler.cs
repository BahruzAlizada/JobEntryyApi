using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.CreateExperience
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommandRequest, CreateExperienceCommandResponse>
    {
        private readonly IExperienceWriteRepository experienceWriteRepository;
        private readonly IExperienceRuleService experienceRuleService;
        public CreateExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository, IExperienceRuleService experienceRuleService)
        {
            this.experienceWriteRepository = experienceWriteRepository;
            this.experienceRuleService = experienceRuleService;
        }


        public async Task<CreateExperienceCommandResponse> Handle(CreateExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(experienceRuleService.CheckNameIfExist(request.Name));
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Experience experience = Domain.Entities.Experience.Create(request.Name);
            await experienceWriteRepository.AddAndSaveAsync(experience);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
