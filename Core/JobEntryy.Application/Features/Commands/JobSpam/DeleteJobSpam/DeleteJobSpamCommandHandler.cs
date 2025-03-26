using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.JobSpam.DeleteJobSpam
{
    public class DeleteJobSpamCommandHandler : IRequestHandler<DeleteJobSpamCommandRequest, DeleteJobSpamCommandResponse>
    {
        private readonly IJobSpamWriteRepository jobSpamWriteRepository;
        public DeleteJobSpamCommandHandler(IJobSpamWriteRepository jobSpamWriteRepository)
        {
            this.jobSpamWriteRepository = jobSpamWriteRepository;
        }


        public async Task<DeleteJobSpamCommandResponse> Handle(DeleteJobSpamCommandRequest request, CancellationToken cancellationToken)
        {
            await jobSpamWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
