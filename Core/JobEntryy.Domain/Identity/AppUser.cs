using JobEntryy.Domain.Entities;
using JobEntryy.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }


        public UserType UserType { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? Updated { get; set; }
        public bool Status { get; set; } = true;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public string? CompanyImageUrl { get; set; }
        public int? JobCount { get; set; }

        public CompanyDetail Detail { get; set; }
        public ICollection<CompanySocialMedia> SocialMedias { get; set; }


        public ICollection<CompanyIndustry> CompanyIndustries { get; set; }
        public ICollection<UserPackage> UserPackages { get; set; }


        public void IncreaseJobCount() => JobCount++;
        public void DecreaseJobCount() => JobCount--;

    }
}
