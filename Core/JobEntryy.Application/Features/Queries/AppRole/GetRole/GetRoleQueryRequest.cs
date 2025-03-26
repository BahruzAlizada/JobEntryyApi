using MediatR;

namespace JobEntryy.Application.Features.Queries.AppRole.GetRole
{
    public class GetRoleQueryRequest : IRequest<GetRoleQueryResponse>
    {
        public Guid Id { get; set; }
    }
}