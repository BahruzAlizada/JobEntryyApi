using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Experience.GetAllExperiences
{
    public class GetAllExperiencesQueryResponse
    {
        public List<ExperienceAllDto> Experiences { get; set; }
        public Result Result { get; set; }
    }
}