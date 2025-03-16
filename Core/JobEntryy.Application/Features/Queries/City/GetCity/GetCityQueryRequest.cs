using MediatR;

namespace JobEntryy.Application.Features.Queries.City.GetCity
{
    public class GetCityQueryRequest : IRequest<GetCityQueryResponse>
    {
        public Guid Id { get; set; }
    }
}