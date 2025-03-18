using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules.Abstract
{
    public interface IJobRuleService
    {
        Task<Result> CheckCategory(Guid categoryId);
        Task<Result> CheckCity(Guid? cityId);
        Task<Result> CheckExperience(Guid experienceId);
        Task<Result> CheckDuplicateJob(Guid userId, Guid categoryId, Guid expId, string name);
        Task<Result> CheckDailyJobLimit(Guid userId);
        Result CheckJobApplicationInfo(string? email, string? link);
        Result CheckJobSalary(bool isSalaryHidden, int salary);
        Result CheckJobTitle(string name);
        Result CheckJobResponsibilities(string responsibilities);
        Result CheckJobRequiredSkills(string requiredSkills);
        Result CheckJobLink(string? link);
    }
}
