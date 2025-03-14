

namespace JobEntryy.Domain.Common
{
    public class AuditBaseEntity : BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? Updated { get; set; }


        public void ChangeUpdated() => Updated = DateTime.UtcNow.AddHours(4);
    }
}
