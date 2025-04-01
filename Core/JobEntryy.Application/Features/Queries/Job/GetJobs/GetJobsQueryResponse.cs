using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Job.GetJobs
{
    public class GetJobsQueryResponse
    {
        public Result Result { get; set; }
        public List<JobDto> Jobs { get; set; }
    }
}