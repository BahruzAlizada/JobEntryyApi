using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Package.GetPackage
{
    public class GetPackageQueryHandler : IRequestHandler<GetPackageQueryRequest, GetPackageQueryResponse>
    {
        private readonly IPackageReadDapper packageReadDapper;
        public GetPackageQueryHandler(IPackageReadDapper packageReadDapper)
        {
            this.packageReadDapper = packageReadDapper;
        }


        public async Task<GetPackageQueryResponse> Handle(GetPackageQueryRequest request, CancellationToken cancellationToken)
        {
            PackageDto? package = await packageReadDapper.GetPackage(request.Id);
            if (package == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            return new() { Package = package, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
