using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Application.Rules.Concrete
{
    public class CompanySocialMediaRuleService : ICompanySocialMediaRuleService
    {
        private readonly ICompanySocialMediaReadRepository companySocialMediaReadRepository;
        private readonly UserManager<AppUser> userManager;
        public CompanySocialMediaRuleService(ICompanySocialMediaReadRepository companySocialMediaReadRepository, UserManager<AppUser> userManager)
        {
            this.companySocialMediaReadRepository = companySocialMediaReadRepository;
            this.userManager = userManager;
        }

        public async Task<Result> CheckCompany(Guid compId)
        {
            AppUser? company = await userManager.Users.Where(x => x.UserType == Domain.Enums.UserType.Company).FirstOrDefaultAsync(x => x.Id == compId);
            if(company==null) return ErrorResult.Create("Şirkət tapılmadı");

            return Result.Create(true);
        }

        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var experienceExist = companySocialMediaReadRepository.GetAll().Any(x => x.Platform == name && x.Id != id);
                if (experienceExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var experienceExist = companySocialMediaReadRepository.GetAll().Any(x => x.Platform == name);
                if (experienceExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
