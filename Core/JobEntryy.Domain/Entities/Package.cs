using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Package : AuditBaseEntity
    {
        public string Name { get; set; }
        public int PremiumJobCount { get; set; }
        public int Price { get; set; }
        
        public ICollection<UserPackage> UserPackages { get; set; }
    }
}
