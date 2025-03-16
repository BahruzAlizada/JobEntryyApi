using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.DeleteIndustry
{
    public class DeleteIndustryCommandRequest : IRequest<DeleteIndustryCommandResponse> 
    {
        public Guid Id { get; set; }
    }
}