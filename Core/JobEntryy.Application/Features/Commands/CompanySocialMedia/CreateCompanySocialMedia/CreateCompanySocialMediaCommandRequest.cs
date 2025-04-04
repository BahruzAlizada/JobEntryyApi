using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.CreateCompanySocialMedia
{
    public class CreateCompanySocialMediaCommandRequest : IRequest<CreateCompanySocialMediaCommandResponse>
    {
        public Guid CompanyId { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
    }
}