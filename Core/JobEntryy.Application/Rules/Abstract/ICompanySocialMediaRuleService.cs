using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface ICompanySocialMediaRuleService
    {
        Task<Result> CheckCompany(Guid compId);
        Result CheckIfNameExisted(string name, Guid? id=null);
    }
}
