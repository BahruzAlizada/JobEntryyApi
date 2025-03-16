using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Package.GetAllPackages
{
    public class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQueryRequest, GetAllPackagesQueryResponse>
    {
        private readonly IPackageReadDapper packageReadDapper;
        public GetAllPackagesQueryHandler(IPackageReadDapper packageReadDapper)
        {
            this.packageReadDapper = packageReadDapper;
        }


        public async Task<GetAllPackagesQueryResponse> Handle(GetAllPackagesQueryRequest request, CancellationToken cancellationToken)
        {
            List<PackageAllDto> packages = await packageReadDapper.GetAllPackages();
            return new() { Packages = packages, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
