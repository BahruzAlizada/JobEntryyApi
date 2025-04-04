using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.UpdateCompanySocialMedia
{
    public class UpdateCompanySocialMediaCommandRequest : IRequest<UpdateCompanySocialMediaCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
    }
}