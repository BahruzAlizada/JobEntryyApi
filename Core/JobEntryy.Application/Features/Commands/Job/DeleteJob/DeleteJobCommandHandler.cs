using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommandRequest,DeleteJobCommandResponse>
    {
        private readonly IJobReadRepository jobReadRepository;
        private readonly IJobWriteRepository jobWriteRepository;
        public DeleteJobCommandHandler(IJobReadRepository jobReadRepository, IJobWriteRepository jobWriteRepository)
        {
            this.jobReadRepository = jobReadRepository;
            this.jobWriteRepository = jobWriteRepository;
        }

        public async Task<DeleteJobCommandResponse> Handle(DeleteJobCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Job? job = await jobReadRepository.GetFindAsync(request.Id);
            if (job == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            jobWriteRepository.Remove(job);
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
