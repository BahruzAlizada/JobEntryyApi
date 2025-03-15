using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts.Services.Dapper
{
    public interface IExperienceReadDapper
    {
        Task<List<ExperienceAllDto>> GetAllExperiences();
        Task<List<ExperienceDto>> GetExperiences();
        Task<ExperienceDto> GetExperience(Guid id);
    }
}
