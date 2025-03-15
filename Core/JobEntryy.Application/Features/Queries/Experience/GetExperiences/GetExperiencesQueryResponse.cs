using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Experience.GetExperiences
{
    public class GetExperiencesQueryResponse
    {
        public List<ExperienceDto> Experiences {  get; set; }
        public Result Result { get; set; }
    }
}