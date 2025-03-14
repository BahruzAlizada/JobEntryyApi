using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.UpdateIndustry
{
    public class UpdateIndustryCommandRequest : IRequest<UpdateIndustryCommandResponse> 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}