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


//En - 55 mm - 5.5 sm
//Hündürlük - 60 mm - 6 sm
//Uzunluq - 80 mm - 8sm
//Klirens - 20 mm - 2 sm
//Çəki fərqi - 356 Kq 