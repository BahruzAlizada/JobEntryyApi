using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IRoleRuleService
    {
        Result CheckNameIfExisted(string name, Guid? id=null);
    }
}
