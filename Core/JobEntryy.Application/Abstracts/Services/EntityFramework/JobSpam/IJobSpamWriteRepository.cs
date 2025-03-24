using JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam;
using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Entities;

namespace JobEntryy.Application.Abstracts.Services.EntityFramework
{
    public interface IJobSpamWriteRepository : IWriteRepository<JobSpam>
    {
        Task CreateJobSpam(CreateJobSpamCommandRequest request);
    }
}
