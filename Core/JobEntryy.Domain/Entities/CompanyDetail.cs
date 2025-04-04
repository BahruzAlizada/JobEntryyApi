using JobEntryy.Domain.Common;
using JobEntryy.Domain.Identity;

namespace JobEntryy.Domain.Entities
{
    public class CompanyDetail : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public AppUser Company { get; set; }

        public string? CompanyDescription { get; set; }
        public string? WebUrl { get; set; }
        public string? Address { get; set; }


    }
}
