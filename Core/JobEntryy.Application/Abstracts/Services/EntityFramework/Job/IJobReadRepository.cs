using JobEntryy.Application.DTOs;
using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Entities;

namespace JobEntryy.Application.Abstracts.Services.EntityFramework
{
    public interface IJobReadRepository : IReadRepository<Job>
    {
        Task<List<JobDto>> GetJobsAsync(JobFilterDto filter, int take);



        Task<decimal?> CalculateCategoryAverageSalary(Guid catId);
        Task<decimal?> CalculateCompanyAverageSalary(Guid compId);
    }
}
