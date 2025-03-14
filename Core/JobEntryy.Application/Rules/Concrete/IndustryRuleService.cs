using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class IndustryRuleService : IIndustryRuleService
    {
        private readonly IIndustryReadRepository industryReadRepository;
        public IndustryRuleService(IIndustryReadRepository industryReadRepository)
        {
            this.industryReadRepository = industryReadRepository;
        }



        public Result CheckNameIfExist(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var industryExist = industryReadRepository.GetAll().Any(x => x.Name == name && x.Id != id);
                if (industryExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var industryExist = industryReadRepository.GetAll().Any(x => x.Name == name);
                if (industryExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
