using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Job : AuditBaseEntity
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; } = DateTime.UtcNow.AddDays(30);
        public int Seen { get; private set; }


    }
}
