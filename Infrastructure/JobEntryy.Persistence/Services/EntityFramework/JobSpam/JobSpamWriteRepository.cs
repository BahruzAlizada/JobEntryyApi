using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class JobSpamWriteRepository : WriteRepository<JobSpam>, IJobSpamWriteRepository
    {
        private readonly Context context;
        public JobSpamWriteRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task CreateJobSpam(CreateJobSpamCommandRequest request)
        {
            Job job = await context.Jobs.FindAsync(request.JobId) ?? throw new Exception("Job not found");

            JobSpam jobSpam = JobSpam.Create(request.JobId, request.Reason, request.SpamDescription, request.ReportedByEmail);
            await context.JobSpams.AddAsync(jobSpam);
            await context.SaveChangesAsync();
        }
    }
}
