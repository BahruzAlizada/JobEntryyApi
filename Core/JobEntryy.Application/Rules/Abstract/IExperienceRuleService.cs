
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IExperienceRuleService
    {
        Result CheckNameIfExist(string name, Guid? id = null);
    }
}
