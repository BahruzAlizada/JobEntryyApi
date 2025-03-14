using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Domain.Entities;

namespace JobEntryy.Application.Rules.Concrete
{
    public class JobRuleService : IJobRuleService
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly ICityReadRepository cityReadRepository;
        private readonly IExperienceReadRepository experienceReadRepository;
        public JobRuleService(ICategoryReadRepository categoryReadRepository, ICityReadRepository cityReadRepository, IExperienceReadRepository experienceReadRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.cityReadRepository = cityReadRepository;
            this.experienceReadRepository = experienceReadRepository;
        }


        public async Task<Result> CheckCategory(Guid categoryId)
        {
            Category? category = await categoryReadRepository.GetFindAsync(categoryId);
            if (category == null)
                return ErrorResult.Create(Messages.IdNull);

            return Result.Create(true);
        }

        public async Task<Result> CheckCity(Guid? cityId)
        {
            if (!cityId.HasValue) return Result.Create(true);
            else
            {
                City? city = await cityReadRepository.GetByIdAsync(cityId.ToString());
                if (city == null)
                    return ErrorResult.Create(Messages.IdNull);

                return Result.Create(true);
            }
        }

        public async Task<Result> CheckExperience(Guid experienceId)
        {
            Experience? experience = await experienceReadRepository.GetFindAsync(experienceId);
            if (experience == null)
                return ErrorResult.Create(Messages.IdNull);

            return Result.Create(true);
        }

        public Result CheckJobApplicationInfo(string? email, string? link)
        {
            if((email==null && link==null) || (email !=null && link != null))
            {
                return ErrorResult.Create("Email və linkin sadəcəni birini doldura bilərsiniz");
            }
            return Result.Create(true);
        }

        public Result CheckJobSalary(bool isSalaryHidden, int salary)
        {
            throw new NotImplementedException();
        }
    }
}
