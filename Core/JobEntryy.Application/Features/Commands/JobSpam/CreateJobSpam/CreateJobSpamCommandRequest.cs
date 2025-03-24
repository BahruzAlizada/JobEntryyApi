using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Domain.Enums;
using MediatR;

namespace JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam
{
    public class CreateJobSpamCommandRequest : IRequest<CreateJobSpamCommandResponse>
    {
        public Guid JobId { get; set; }
        public SpamReason Reason { get; set; }
        public string? SpamDescription { get; set; }
        public string ReportedByEmail { get; set; }
    }
}