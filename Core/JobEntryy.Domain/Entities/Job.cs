using JobEntryy.Domain.Common;
using JobEntryy.Domain.Enums;
using JobEntryy.Domain.Identity;
using JobEntryy.Domain.ValueObjects;

namespace JobEntryy.Domain.Entities
{
    public class Job : AuditBaseEntity
    {
        public string Name { get; set; }
        public JobSalary Salary { get; set; }
        public DateTime Deadline { get; set; } = DateTime.UtcNow.AddDays(30);
        public int Seen { get; set; }


        public bool IsPremium { get; set; } = false;
        public DateTime? PremiumDate { get; set; }


        public JobType JobType { get; set; }
        public WorkMode? WorkMode { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public EducationLevel? EducationLevel { get; set; }



        public JobDetail JobDetail { get; set; }
        public JobApplicationInfo JobApplicationInfo { get; set; }  


        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid ExperienceId { get; set; }


        public AppUser User { get; set; }        
        public Category Category { get; set; }
        public City? City { get; set; }
        public Experience Experience { get; set; }


        public void SetJobPremium()
        {
            PremiumDate = DateTime.UtcNow.AddDays(2);
            IsPremium = true;
        }

        public void SetJobNormal()
        {
            IsPremium = false;
            PremiumDate = null;
        }



    }
}
