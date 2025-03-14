using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class CityRuleService : ICityRuleService
    {
        private readonly ICityReadRepository cityReadRepository;
        public CityRuleService(ICityReadRepository cityReadRepository)
        {
            this.cityReadRepository = cityReadRepository;
        }


        public Result CheckNameIfExist(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var cityExist = cityReadRepository.GetAll().Any(x => x.Name == name && x.Id != id);
                if (cityExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var cityExist = cityReadRepository.GetAll().Any(x => x.Name == name);
                if (cityExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
