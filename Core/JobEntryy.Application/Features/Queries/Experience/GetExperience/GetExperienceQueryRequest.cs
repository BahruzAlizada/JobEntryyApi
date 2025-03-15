using MediatR;

namespace JobEntryy.Application.Features.Queries.Experience.GetExperience
{
    public class GetExperienceQueryRequest : IRequest<GetExperienceQueryResponse>
    {
        public Guid Id { get; set; }
    }
}