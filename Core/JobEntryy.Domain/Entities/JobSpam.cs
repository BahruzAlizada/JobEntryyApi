using JobEntryy.Domain.Common;
using JobEntryy.Domain.Enums;

namespace JobEntryy.Domain.Entities
{
    public class JobSpam : BaseEntity
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public SpamReason Reason { get; set; }
        public string? SpamDescription { get; set; }
        public string ReportedByEmail { get; set; } 
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow.AddHours(4);



        public static JobSpam Create(Guid jobId, SpamReason reason, string? spamDescription, string reportedByEmail)
        {
            JobSpam spam = new JobSpam
            {
                JobId = jobId,
                Reason = reason,
                SpamDescription = spamDescription,
                ReportedByEmail = reportedByEmail
            };

            return spam;
        }

    }
}
