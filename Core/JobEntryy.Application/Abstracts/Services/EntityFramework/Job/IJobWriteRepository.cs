﻿using JobEntryy.Application.Features.Commands.Job.CreateJob;
using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Entities;

namespace JobEntryy.Application.Abstracts.Services.EntityFramework
{
    public interface IJobWriteRepository : IWriteRepository<Job>
    {
        Task CreateJobAsync(CreateJobCommandRequest request);
        Task RepublishJob(Guid jobId);
        Task SetJobPremium(Guid userId, Guid jobId);
        Task ChangeJobStatusForSpams(Guid jobId);

    }
}
