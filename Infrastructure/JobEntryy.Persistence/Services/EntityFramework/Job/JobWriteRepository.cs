﻿using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Exceptions;
using JobEntryy.Application.Features.Commands.Job.CreateJob;
using JobEntryy.Domain.Entities;
using JobEntryy.Domain.Identity;
using JobEntryy.Domain.ValueObjects;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Services.EntityFramework;

public class JobWriteRepository : WriteRepository<Job>, IJobWriteRepository
{
    private readonly Context context;
    private readonly UserManager<AppUser> userManager;
    public JobWriteRepository(Context context, UserManager<AppUser> userManager) : base(context)
    {
        this.context = context;
        this.userManager = userManager;
    }


    public async Task CreateJobAsync(CreateJobCommandRequest request)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            AppUser? user = await userManager.FindByIdAsync(request.UserId.ToString()) ?? throw new UserNotFoundException();
            
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

            user.IncreaseJobCount();
            await userManager.UpdateAsync(user);

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error occured while job created" + ex.Message);
        }
    }

    public async Task RepublishJob(Guid jobId)
    {
        Job job = await context.Jobs.FindAsync(jobId) ?? throw new Exception("Job not found");
        
        job.Deadline = DateTime.UtcNow.AddMonths(30);
        if (job.IsPremium)
            job.SetJobNormal();

        context.Jobs.Update(job);
        await context.SaveChangesAsync();
    }

    public async Task SetJobPremium(Guid userId, Guid jobId)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            AppUser user = await userManager.FindByIdAsync(userId.ToString()) ?? throw new UserNotFoundException();
            Job job = await context.Jobs.FindAsync(jobId) ?? throw new Exception("Job not found");
            UserPackage userPackage = await context.UserPackages.FirstOrDefaultAsync(x => x.UserId == userId) ?? throw new Exception("User's package is empty");

            job.SetJobPremium();
            userPackage.UsePackage();

            if (userPackage.RemainingPremiumJobCount == 0) 
                context.UserPackages.Remove(userPackage);

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Error occured while job set premium" + ex.Message);
        }
    }
}
