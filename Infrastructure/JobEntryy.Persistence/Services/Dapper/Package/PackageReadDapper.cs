using System.Data.Common;
using Dapper;
using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.DTOs;

namespace JobEntryy.Persistence.Services.Dapper
{ 
    public class PackageReadDapper : IPackageReadDapper
    {
        private readonly DbConnection connection;
        public PackageReadDapper(DbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<List<PackageAllDto>> GetAllPackages()
        {
            var query = "SELECT Id, Name, PremiumJobCount, Price, Created, Updated  FROM Packages";
            var packages = await connection.QueryAsync<PackageAllDto>(query);
            return packages.AsList();
        }

        public async Task<PackageDto> GetPackage(Guid id)
        {
            var query = "SELECT Id, Name, PremiumJobCount, Price FROM Packages WHERE Id=@Id AND Status = 1";
            var package = await connection.QueryFirstOrDefaultAsync<PackageDto>(query, new { Id = id });
            return package;
        }

        public async Task<List<PackageDto>> GetPackages()
        {
            var query = "SELECT Id, Name, PremiumJobCount, Price FROM Packages WHERE Status = 1";
            var packages = await connection.QueryAsync<PackageDto>(query);
            return packages.AsList();
        }
    }
}
