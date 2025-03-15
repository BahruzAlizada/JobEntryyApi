using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Experience.GetExperiences
{
    public class GetExperiencesQueryHandler : IRequestHandler<GetExperiencesQueryRequest, GetExperiencesQueryResponse>
    {
        private readonly IExperienceReadDapper experienceReadDapper;
        public GetExperiencesQueryHandler(IExperienceReadDapper experienceReadDapper)
        {
            this.experienceReadDapper = experienceReadDapper;
        }


        public async Task<GetExperiencesQueryResponse> Handle(GetExperiencesQueryRequest request, CancellationToken cancellationToken)
        {
            List<ExperienceDto> experiences = await experienceReadDapper.GetExperiences();
            return new() { Experiences = experiences, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
