using JobEntryy.Domain.Common;
using JobEntryy.Domain.Identity;

namespace JobEntryy.Domain.Entities
{
    public class UserPackage : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PackageId {  get; set; }
        public AppUser User { get; set; }
        public Package Package { get; set; }


    }
}
