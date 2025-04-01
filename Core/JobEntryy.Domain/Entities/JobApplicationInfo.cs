using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class JobApplicationInfo : BaseEntity
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }

        public string? Email { get; set; }
        public string? Link { get; set; }



        public static JobApplicationInfo Create(Guid jobId,string? email,string? link)
        {
            JobApplicationInfo info = new JobApplicationInfo
            {
                JobId = jobId,
                Email = email,
                Link = link
            };
            return info;
        }
    }
}
