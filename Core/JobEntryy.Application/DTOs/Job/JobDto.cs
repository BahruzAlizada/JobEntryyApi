

namespace JobEntryy.Application.DTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Seen { get; set; }
        public DateTime Created { get; set; }
        public string CompanyName { get; set; }
        public string CompanyImage { get; set; }
        public Guid CompanyId { get; set; }
        public bool IsPremium { get; set; }
    }
}
