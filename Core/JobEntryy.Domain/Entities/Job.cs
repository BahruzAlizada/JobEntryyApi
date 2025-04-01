using System.ComponentModel.DataAnnotations.Schema;
using JobEntryy.Domain.Common;
using JobEntryy.Domain.Enums;
using JobEntryy.Domain.Identity;
using JobEntryy.Domain.ValueObjects;
using MediatR;

namespace JobEntryy.Domain.Entities
{
    public class Job : AuditBaseEntity
    {
        public string Name { get; set; }
        [NotMapped]
        public JobSalary Salary { get; set; }

        public DateTime Deadline { get; set; } = DateTime.UtcNow.AddDays(30);
        public int Seen { get; set; } = 0;

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



        public ICollection<JobSpam> Spams { get; set; }


        
        public static Job Create(string name, bool isSalaryHidden, int salary, JobType jobType, WorkMode? workMode, EmploymentType? employmentType,
            EducationLevel? educationLevel, Guid userId, Guid categoryId, Guid? cityId, Guid experienceId)
        {
            Job job = new Job
            {
                Name = name,
                Salary = JobSalary.Create(isSalaryHidden, salary),
                JobType = jobType,
                WorkMode = workMode,
                EmploymentType = employmentType,
                EducationLevel = educationLevel,
                UserId = userId,
                CategoryId = categoryId,
                CityId = cityId,
                ExperienceId = experienceId,
            };
            return job;
        }

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

        public void ChangeJobName(string newName) => Name = newName;
        public void ChangeJobSalary(int salary, bool isSalaryHidden)=>JobSalary.Create(isSalaryHidden, salary); 

         
    }
}
