using JobEntryy.Domain.Identity;

namespace JobEntryy.Domain.Entities
{
    public class CompanyIndustry
    {
        public Guid IndustryId { get; set; }
        public Industry Industry { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
