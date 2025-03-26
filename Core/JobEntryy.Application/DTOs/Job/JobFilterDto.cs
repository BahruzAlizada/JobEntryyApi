

using JobEntryy.Domain.Enums;

namespace JobEntryy.Application.DTOs
{
    public class JobFilterDto
    {
        public string? Search { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? ExperienceId { get; set; }
        public Guid? IndustryId { get; set; }
        public JobType? JobType { get; set; }
        public WorkMode? WorkMode { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
    }
}
