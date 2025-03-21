using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.SetJobPremium
{
    public class SetJobPremiumCommandHandler : IRequestHandler<SetJobPremiumCommandRequest, SetJobPremiumCommandResponse>
    {
        private readonly IJobWriteRepository jobWriteRepository;
        public SetJobPremiumCommandHandler(IJobWriteRepository jobWriteRepository)
        {
            this.jobWriteRepository = jobWriteRepository;
        }



        public async Task<SetJobPremiumCommandResponse> Handle(SetJobPremiumCommandRequest request, CancellationToken cancellationToken)
        {
            await jobWriteRepository.SetJobPremium(request.UserId,request.JobId);
            return new() { Result = SuccessResult.Create("Success Job Premium") };
        }
    }
}
