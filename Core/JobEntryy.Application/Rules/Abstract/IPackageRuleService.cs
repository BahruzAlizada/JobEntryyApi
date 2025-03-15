
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IPackageRuleService
    {
        Result CheckNameIfExist(string name, Guid? id = null);
        Result CheckPremiumJobCount(int premiumJobCount);
        Result CheckPrice(int price);
    }
}
