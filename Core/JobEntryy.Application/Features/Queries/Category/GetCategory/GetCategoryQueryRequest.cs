using MediatR;

namespace JobEntryy.Application.Features.Queries.Category.GetCategory
{
    public class GetCategoryQueryRequest : IRequest<GetCategoryQueryResponse>
    {
        public Guid Id { get; set; }
    }
}