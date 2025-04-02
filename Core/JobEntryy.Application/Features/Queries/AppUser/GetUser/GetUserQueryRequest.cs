using MediatR;

namespace JobEntryy.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public Guid Id { get; set; }
    }
}