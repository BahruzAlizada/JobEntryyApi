using JobEntryy.Domain.Common;
using JobEntryy.Domain.Identity;

namespace JobEntryy.Domain.Entities
{
    public class CompanySocialMedia : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public AppUser Company { get; set; }


        public string Platform { get; set; }
        public string Url { get; set; }



        public static CompanySocialMedia Create(Guid companyId, string platform, string url)
        {
            return new CompanySocialMedia
            {
                CompanyId = companyId,
                Platform = platform,
                Url = url
            };
        }
    }
}
