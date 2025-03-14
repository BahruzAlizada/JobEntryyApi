using JobEntryy.Domain.Entities;

namespace JobEntryy.Domain.Identity
{
    public class AppUser
    {
        public string Name { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
