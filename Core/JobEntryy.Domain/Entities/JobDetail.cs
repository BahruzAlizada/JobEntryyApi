using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class JobDetail : BaseEntity
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public string RequiredSkills { get; set; }
        public string Responsibilities { get; set; }
        public string? JobGraphics { get; set; }

        public static JobDetail Create(Guid jobId, string requriedSkills, string responsibilities, string? jobGraphics)
        {
            JobDetail jobDetail = new JobDetail
            {
                JobId = jobId,
                RequiredSkills = requriedSkills,
                Responsibilities = responsibilities,
                JobGraphics = jobGraphics
            };
            return jobDetail;
        }
    }
}
