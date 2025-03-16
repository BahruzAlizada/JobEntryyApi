
using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts.Services.Dapper
{
    public interface IPackageReadDapper
    {
        Task<List<PackageAllDto>> GetAllPackages();
        Task<List<PackageDto>> GetPackages();
        Task<PackageDto> GetPackage(Guid id);
    }
}
