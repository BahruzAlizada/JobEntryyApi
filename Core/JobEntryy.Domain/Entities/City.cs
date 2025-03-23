using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
} 
