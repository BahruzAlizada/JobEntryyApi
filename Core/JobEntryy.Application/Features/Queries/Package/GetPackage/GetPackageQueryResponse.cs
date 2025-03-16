using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Package.GetPackage
{
    public class GetPackageQueryResponse
    {
        public Result Result { get; set; }
        public PackageDto? Package { get; set; }
    }
}