using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Features.Commands.Job.CreateJob;
using JobEntryy.Domain.Entities;
using JobEntryy.Domain.ValueObjects;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework;

public class JobWriteRepository : WriteRepository<Job>, IJobWriteRepository
{
    private readonly Context context;
    public JobWriteRepository(Context context) : base(context)
    {
        this.context = context;
    }


    public async Task CreateJobAsync(CreateJobCommandRequest request)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            Job job = new Job
            {
                Name = request.Name,
                Salary = JobSalary.Create(request.IsSalaryHidden, request.Salary),
                JobType = request.JobType,
                WorkMode = request.WorkMode,
                EmploymentType = request.EmploymentType,
                EducationLevel = request.EducationLevel,
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CityId = request.CityId,
                ExperienceId = request.ExperienceId,
            };
            await context.Jobs.AddAsync(job);


            JobDetail jobDetail = new JobDetail
            {
                JobId = job.Id,
                RequiredSkills = request.RequiredSkills,
                Responsibilities = request.Responsibilities,
                JobGraphics = request.JobGraphics,
            };
            await context.JobDetails.AddAsync(jobDetail);


            JobApplicationInfo jobApplicationInfo = new JobApplicationInfo
            {
                JobId = job.Id,
                Email = request.Email,
                Link = request.Link,
            };
            await context.JobApplicationInfos.AddAsync(jobApplicationInfo);

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error occured while job created" + ex.Message);
        }
    }
}
