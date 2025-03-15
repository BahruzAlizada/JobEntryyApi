using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class PackageRuleService : IPackageRuleService
    {
        private readonly IPackageReadRepository packageReadRepository;
        public PackageRuleService(IPackageReadRepository packageReadRepository)
        {
            this.packageReadRepository = packageReadRepository;
        }


        public Result CheckNameIfExist(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var packageExist = packageReadRepository.GetAll().Any(x => x.Name == name && x.Id != id);
                if (packageExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var packageExist = packageReadRepository.GetAll().Any(x => x.Name == name);
                if (packageExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }

        public Result CheckPremiumJobCount(int premiumJobCount)
        {
            if (premiumJobCount < 1 || premiumJobCount > 50)
                return ErrorResult.Create("Premium iş elan sayısı 1 ilə 50 arasında olmalıdır");

            return Result.Create(true);
        }

        public Result CheckPrice(int price)
        {
            if (price < 15 || price > 10000)
                return ErrorResult.Create("Premium iş elan paketinin qiyməti 15 ilə 10000 Azn arasında olmalıdır");

            return Result.Create(true);
        }
    }
}
