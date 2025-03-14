using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Industry : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
