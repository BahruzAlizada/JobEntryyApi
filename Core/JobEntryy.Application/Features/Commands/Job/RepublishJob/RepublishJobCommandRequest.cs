using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.RepublishJob
{
    public class RepublishJobCommandRequest : IRequest<RepublishJobCommandResponse>
    {
        public Guid Id { get; set; }
    }
}