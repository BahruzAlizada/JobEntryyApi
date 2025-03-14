using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IJobRuleService
    {
        Task<Result> CheckCategory(Guid categoryId);
        Task<Result> CheckCity(Guid? cityId);
        Task<Result> CheckExperience(Guid experienceId);
        Result CheckJobApplicationInfo(string? email, string? link);
        Result CheckJobSalary(bool isSalaryHidden, int salary);
    }
}
