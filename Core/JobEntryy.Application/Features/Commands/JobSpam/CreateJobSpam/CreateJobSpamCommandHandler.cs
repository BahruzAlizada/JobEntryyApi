using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using MediatR;

namespace JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam
{
    public class CreateJobSpamCommandHandler : IRequestHandler<CreateJobSpamCommandRequest, CreateJobSpamCommandResponse>
    {
        private readonly IJobSpamWriteRepository jobSpamWriteRepository;
        private readonly IJobSpamRuleService jobSpamRuleService;
        public CreateJobSpamCommandHandler(IJobSpamWriteRepository jobSpamWriteRepository, IJobSpamRuleService jobSpamRuleService)
        {
            this.jobSpamWriteRepository = jobSpamWriteRepository;
            this.jobSpamRuleService = jobSpamRuleService;
        }


        public async Task<CreateJobSpamCommandResponse> Handle(CreateJobSpamCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(jobSpamRuleService.CheckJobSpam(request.JobId, request.ReportedByEmail), jobSpamRuleService.CheckJobSpamDescription(request.SpamDescription));
            if (!result.Success) return new() { Result = result };

            await jobSpamWriteRepository.CreateJobSpam(request);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
