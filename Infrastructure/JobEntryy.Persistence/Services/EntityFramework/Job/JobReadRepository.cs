using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.DTOs;
using JobEntryy.Domain.Entities;
using JobEntryy.Domain.Enums;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Services.EntityFramework;

public class JobReadRepository : ReadRepository<Job>, IJobReadRepository
{
    private readonly Context context;
    public JobReadRepository(Context context) : base(context)
    {
        this.context = context;
    }

    public async Task<List<JobDto>> GetJobsAsync(JobFilterDto filter)
    {
        IQueryable<Job> jobQuery = context.Jobs.Include(x=>x.User).Where(x => x.Status && x.Deadline >= DateTime.UtcNow)
            .OrderByDescending(x => x.IsPremium).ThenByDescending(x=>x.Created);

        if(!string.IsNullOrEmpty(filter.Search))
            jobQuery = jobQuery.Where(x => x.Name.Contains(filter.Search));

        if(filter.CompanyId != null)
            jobQuery = jobQuery.Where(x => x.UserId == filter.CompanyId);

        if (filter.CategoryId!=null)
            jobQuery = jobQuery.Where(x => x.CategoryId == filter.CategoryId);

        if(filter.CityId != null)
            jobQuery = jobQuery.Where(x => x.CityId == filter.CityId);

        if (filter.ExperienceId != null)
            jobQuery = jobQuery.Where(x => x.ExperienceId == filter.ExperienceId);

        if (filter.IndustryId != null)
            jobQuery = jobQuery.Where(x => x.User.CompanyIndustries.Any(x => x.IndustryId == filter.IndustryId));

        if (filter.JobType != null)
            jobQuery = jobQuery.Where(x => x.JobType == filter.JobType);

        if(filter.WorkMode != null)
            jobQuery = jobQuery.Where(x => x.WorkMode == filter.WorkMode);

        if(filter.EmploymentType != null)
            jobQuery = jobQuery.Where(x => x.EmploymentType == filter.EmploymentType);

        if(filter.EducationLevel != null)
            jobQuery = jobQuery.Where(x => x.EducationLevel == filter.EducationLevel);

        if (filter.MinSalary != null)
            jobQuery = jobQuery.Where(x => !x.Salary.IsSalaryHidden && x.Salary.Salary >= filter.MinSalary);

        if (filter.MaxSalary != null)
            jobQuery = jobQuery.Where(x => !x.Salary.IsSalaryHidden && x.Salary.Salary <= filter.MaxSalary);

        List<JobDto> jobs = await jobQuery.Select(x => new JobDto
        {
            Id = x.Id,
            Name = x.Name,
            Seen = x.Seen,
            CompanyName = x.User.Name,
            CompanyId = x.UserId,
            CompanyImage = x.User.CompanyImageUrl,
            Created = x.Created,
            IsPremium = x.IsPremium,
        }).Take(35).ToListAsync();

        return jobs;
    }
}
