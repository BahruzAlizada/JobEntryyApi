using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.DeleteJob
{
    public class DeleteJobCommandRequest : IRequest<DeleteJobCommandResponse>
    {
        public Guid Id { get; set; }
    }
}