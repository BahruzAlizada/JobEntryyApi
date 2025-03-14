

using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class JobApplicationInfo : BaseEntity
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public string? Email { get; set; }
        public string? Link { get; set; }
    }
}
