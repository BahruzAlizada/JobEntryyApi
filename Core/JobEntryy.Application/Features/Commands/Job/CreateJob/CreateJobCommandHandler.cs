using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Extensions;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommandRequest, CreateJobCommandResponse>
    {
        private readonly IJobWriteRepository jobWriteRepository;
        private readonly IJobRuleService jobRuleService;
        public CreateJobCommandHandler(IJobWriteRepository jobWriteRepository, IJobRuleService jobRuleService)
        {
            this.jobWriteRepository = jobWriteRepository;
            this.jobRuleService = jobRuleService;
        }



        public async Task<CreateJobCommandResponse> Handle(CreateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await CheckBusinessRules(request);
            if (!result.Success) return new() { Result = result };

            await jobWriteRepository.CreateJobAsync(request);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }




        private async Task<Result> CheckBusinessRules(CreateJobCommandRequest request)
        {
            var result = BusinessRules.Run
            (
                await jobRuleService.CheckCategory(request.CategoryId),
                await jobRuleService.CheckCity(request.CityId),
                await jobRuleService.CheckExperience(request.ExperienceId),
                jobRuleService.CheckJobApplicationInfo(request.Email,request.Link),
                jobRuleService.CheckJobSalary(request.IsSalaryHidden,request.Salary)
            );

            return result;
        }
    }
}
