using MediatR;

namespace JobEntryy.Application.Features.Commands.JobSpam.DeleteJobSpam
{
    public class DeleteJobSpamCommandRequest : IRequest<DeleteJobSpamCommandResponse>   
    {
        public Guid Id { get; set; }
    }
}