using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCitiesWithPaged
{
    public class GetCitiesWithPagedRequest : IRequest<GetCitiesWithPagedResponse>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; } 
    }
}