using JobEntryy.Application.DTOs;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Job.GetJobs
{
    public class GetJobsQueryRequest : IRequest<GetJobsQueryResponse>
    {
        public JobFilterDto? Filter { get; set; }
    }
}