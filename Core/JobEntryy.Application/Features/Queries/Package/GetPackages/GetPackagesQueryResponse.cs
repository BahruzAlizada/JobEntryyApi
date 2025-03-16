using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Package.GetPackages
{
    public class GetPackagesQueryResponse
    {
        public Result Result { get; set; }
        public List<PackageDto> Packages { get; set; }
    }
}