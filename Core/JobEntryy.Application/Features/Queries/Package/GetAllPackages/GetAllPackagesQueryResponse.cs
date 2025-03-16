using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Package.GetAllPackages
{
    public class GetAllPackagesQueryResponse
    {
        public Result Result { get; set; }
        public List<PackageAllDto> Packages { get; set; }
    }
}