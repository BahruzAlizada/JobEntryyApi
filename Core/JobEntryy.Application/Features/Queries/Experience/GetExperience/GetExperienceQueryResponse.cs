using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Experience.GetExperience
{
    public class GetExperienceQueryResponse
    {
        public Result Result { get; set; }
        public ExperienceDto? Experience { get; set; }
    }
}