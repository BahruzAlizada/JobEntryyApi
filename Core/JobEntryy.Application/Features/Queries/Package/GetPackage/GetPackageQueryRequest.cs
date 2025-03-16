using MediatR;

namespace JobEntryy.Application.Features.Queries.Package.GetPackage
{
    public class GetPackageQueryRequest : IRequest<GetPackageQueryResponse>
    {
        public Guid Id { get; set; }
    }
}