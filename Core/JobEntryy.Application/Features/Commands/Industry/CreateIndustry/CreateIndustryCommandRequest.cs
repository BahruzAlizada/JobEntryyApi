using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.CreateIndustry
{
    public class CreateIndustryCommandRequest : IRequest<CreateIndustryCommandResponse>
    {
        public string Name { get; set; }
    }
}