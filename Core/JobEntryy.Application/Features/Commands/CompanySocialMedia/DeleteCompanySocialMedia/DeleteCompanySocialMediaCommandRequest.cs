using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.DeleteCompanySocialMedia
{
    public class DeleteCompanySocialMediaCommandRequest : IRequest<DeleteCompanySocialMediaCommandResponse>
    {
        public Guid Id { get; set; }
    }
}