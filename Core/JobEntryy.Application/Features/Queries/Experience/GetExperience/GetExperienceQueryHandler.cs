using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Experience.GetExperience
{
    public class GetExperienceQueryHandler : IRequestHandler<GetExperienceQueryRequest, GetExperienceQueryResponse>
    {
        private readonly IExperienceReadDapper experienceReadDapper;
        public GetExperienceQueryHandler(IExperienceReadDapper experienceReadDapper)
        {
            this.experienceReadDapper = experienceReadDapper;
        }


        public async Task<GetExperienceQueryResponse> Handle(GetExperienceQueryRequest request, CancellationToken cancellationToken)
        {
            ExperienceDto? experience = await experienceReadDapper.GetExperience(request.Id);
            if (experience == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            return new() { Experience = experience, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
