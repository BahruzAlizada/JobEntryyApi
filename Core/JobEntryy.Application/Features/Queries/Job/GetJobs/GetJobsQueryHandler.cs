using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Job.GetJobs
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQueryRequest, GetJobsQueryResponse>
    {
        private readonly IJobReadRepository jobReadRepository;
        public GetJobsQueryHandler(IJobReadRepository jobReadRepository)
        {
            this.jobReadRepository = jobReadRepository;
        }


        public async Task<GetJobsQueryResponse> Handle(GetJobsQueryRequest request, CancellationToken cancellationToken)
        {
            List<JobDto> jobs = await jobReadRepository.GetJobsAsync(request.Filter);
            return new() { Jobs = jobs, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
