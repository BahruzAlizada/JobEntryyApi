

using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface ICategoryRuleService
    {
        Result CheckNameIfExist(string name, Guid? id = null);
    }
}
