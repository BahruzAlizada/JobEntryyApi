using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.UpdateExperience
{
    public class UpdateExperienceCommandRequest : IRequest<UpdateExperienceCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}