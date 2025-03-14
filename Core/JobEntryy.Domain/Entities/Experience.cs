using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
