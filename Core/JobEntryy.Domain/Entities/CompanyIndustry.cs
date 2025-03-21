using JobEntryy.Domain.Common;
using JobEntryy.Domain.Identity;

namespace JobEntryy.Domain.Entities
{
    public class CompanyIndustry : BaseEntity
    {
        public Guid IndustryId { get; set; }
        public Industry Industry { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }




        public static CompanyIndustry Create(Guid userId, Guid industryId)
        {
            return new CompanyIndustry
            {
                IndustryId = industryId,
                UserId = userId,
            };
        }
    }
}
