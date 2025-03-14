using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.DeleteExperience
{
    public class DeleteExperienceCommandRequest : IRequest<DeleteExperienceCommandResponse>
    {
        public Guid Id { get; set; }
    }
}