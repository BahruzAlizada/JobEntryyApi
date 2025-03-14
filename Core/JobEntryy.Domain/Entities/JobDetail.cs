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
    }
}
