using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.RepublishJob
{
    public class RepublishJobCommandHandler : IRequestHandler<RepublishJobCommandRequest, RepublishJobCommandResponse>
    {
        private readonly IJobWriteRepository jobWriteRepository;
        public RepublishJobCommandHandler(IJobWriteRepository jobWriteRepository)
        {
            this.jobWriteRepository = jobWriteRepository;
        }


        public async Task<RepublishJobCommandResponse> Handle(RepublishJobCommandRequest request, CancellationToken cancellationToken)
        {
            await jobWriteRepository.RepublishJob(request.Id);
            return new() { Result = SuccessResult.Create("Republish Job Success") };
        }
    }
}
