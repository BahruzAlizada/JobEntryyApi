using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.SetJobPremium
{
    public class SetJobPremiumCommandRequest : IRequest<SetJobPremiumCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
    }
}