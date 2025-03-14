using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.CreateExperience
{
    public class CreateExperienceCommandRequest : IRequest<CreateExperienceCommandResponse>
    {
        public string Name { get; set; }
    }
}