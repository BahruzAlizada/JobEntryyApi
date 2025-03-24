using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class JobSpamRuleService : IJobSpamRuleService
    {
        private readonly IJobSpamReadRepository jobSpamReadRepository;
        public JobSpamRuleService(IJobSpamReadRepository jobSpamReadRepository)
        {
            this.jobSpamReadRepository = jobSpamReadRepository;
        }


        public Result CheckJobSpam(Guid jobId, string email)
        {
            bool jobSpamResult = jobSpamReadRepository.GetAll().Any(x => x.JobId == jobId && x.ReportedByEmail == email);
            if (jobSpamResult)
                return ErrorResult.Create("You have already reported this job as spam");

            return Result.Create(true);
        }

        public Result CheckJobSpamDescription(string? description)
        {
            if(description != null)
            {
                if (description.Length >= 400)
                    return ErrorResult.Create("Description length should be less than 400 characters.");
            }
           
            return Result.Create(true);
        }
    }
}
