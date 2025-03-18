using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Application.Rules.Concrete
{
    public class JobRuleService : IJobRuleService
    {
        private readonly IJobReadRepository jobReadRepository;
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly ICityReadRepository cityReadRepository;
        private readonly IExperienceReadRepository experienceReadRepository;
        public JobRuleService(IJobReadRepository jobReadRepository, ICategoryReadRepository categoryReadRepository, ICityReadRepository cityReadRepository, IExperienceReadRepository experienceReadRepository)
        {
            this.jobReadRepository = jobReadRepository;
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

        public async Task<Result> CheckDailyJobLimit(Guid userId)
        {
            int todayJobCount = await jobReadRepository.GetWhere(x => x.UserId == userId &&
                                                                            x.Created >= DateTime.UtcNow.Date).CountAsync();
            if (todayJobCount >= 15)
                return ErrorResult.Create("Siz bu gün maksimum elan sayına çatmısınız.");

            return Result.Create(true);
        }

        public async Task<Result> CheckDuplicateJob(Guid userId, Guid catId, Guid expId, string name)
        {
            Job? job = await jobReadRepository.GetSingleAsync
                (x=>x.UserId==userId && x.CategoryId==catId && x.ExperienceId==expId && x.Name.ToLower()==name.ToLower() && x.Status);
            if (job != null) return ErrorResult.Create($"Bu kateqoriyada və təcrübə '{name}' adlı elan artıq mövcuddur");

            return Result.Create(true);
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

        public Result CheckJobLink(string? link)
        {
            if (link == null) return Result.Create(true);

            var result = IsValidUrl(link);
            if (!result) return ErrorResult.Create("Linki düzgün şəkildə daxil etmək lazımdır");

            return Result.Create(true);
        }

        public Result CheckJobRequiredSkills(string requiredSkills)
        {
            if (requiredSkills.Length <= 50)
                return ErrorResult.Create("Vakansiya aid Tələb olunan bacarıqlar bölməsi ən az 50 simvol olmalıdır");

            return Result.Create(true);
        }

        public Result CheckJobResponsibilities(string responsibilities)
        {
            if (responsibilities.Length <= 50)
                return ErrorResult.Create("Vakansiya aid məsuliyyətlər bölməsi ən az 50 simvol olmalıdır");

            return Result.Create(true);
        }

        public Result CheckJobSalary(bool isSalaryHidden, int salary)
        {
            throw new NotImplementedException();
        }

        public Result CheckJobTitle(string name)
        {
            if (name.Length > 120)
                return ErrorResult.Create("Vakansiya adında ən çox 120 simvol ola bilər");

            return Result.Create(true);
        }





        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) 
           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
