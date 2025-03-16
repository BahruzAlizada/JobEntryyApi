using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Package.GetPackages
{
    public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQueryRequest, GetPackagesQueryResponse>
    {
        private readonly IPackageReadDapper packageReadDapper;
        public GetPackagesQueryHandler(IPackageReadDapper packageReadDapper)
        {
            this.packageReadDapper = packageReadDapper;
        }

            
        public async Task<GetPackagesQueryResponse> Handle(GetPackagesQueryRequest request, CancellationToken cancellationToken)
        {
            List<PackageDto> packages = await packageReadDapper.GetPackages();
            return new() { Packages = packages, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
