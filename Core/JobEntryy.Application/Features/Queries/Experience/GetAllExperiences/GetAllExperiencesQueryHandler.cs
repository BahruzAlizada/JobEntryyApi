using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Experience.GetAllExperiences
{
    public class GetAllExperiencesQueryHandler : IRequestHandler<GetAllExperiencesQueryRequest, GetAllExperiencesQueryResponse>
    {
        private readonly IExperienceReadDapper experienceReadDapper;
        public GetAllExperiencesQueryHandler(IExperienceReadDapper experienceReadDapper)
        {
            this.experienceReadDapper = experienceReadDapper;
        }


        public async Task<GetAllExperiencesQueryResponse> Handle(GetAllExperiencesQueryRequest request, CancellationToken cancellationToken)
        {
            List<ExperienceAllDto> experienceAllDtos = await experienceReadDapper.GetAllExperiences();
            return new() { Experiences = experienceAllDtos, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
