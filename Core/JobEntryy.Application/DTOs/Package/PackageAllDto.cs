

namespace JobEntryy.Application.DTOs
{
    public class PackageAllDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PremiumJobCount { get; set; }
        public int Price { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
