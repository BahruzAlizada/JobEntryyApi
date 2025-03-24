using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IJobSpamRuleService
    {
        Result CheckJobSpam(Guid jobId, string email);
        Result CheckJobSpamDescription(string? description);
    }
}
