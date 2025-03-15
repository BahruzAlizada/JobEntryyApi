using System.Data.Common;
using Dapper;
using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.DTOs;

namespace JobEntryy.Persistence.Services.Dapper
{
    public class ExperienceReadDapper : IExperienceReadDapper
    {
        private readonly DbConnection connection;
        public ExperienceReadDapper(DbConnection connection)
        {
            this.connection = connection;   
        }


        public async Task<List<ExperienceAllDto>> GetAllExperiences()
        {
            var query = "SELECT Id, Name, Status FROM Experiences";
            var experiences = await connection.QueryAsync<ExperienceAllDto>(query);
            return experiences.AsList();
        }

        public async Task<ExperienceDto> GetExperience(Guid id)
        {
            var query = "SELECT Id, Name FROM Experiences WHERE Status=1 AND Id=@Id";
            var experience = await connection.QueryFirstOrDefaultAsync<ExperienceDto>(query, new { Id = id });
            return experience;  
        }

        public async Task<List<ExperienceDto>> GetExperiences()
        {
            var query = "SELECT Id, Name FROM Experiences WHERE Status=1";
            var experiences = await connection.QueryAsync<ExperienceDto>(query);
            return experiences.AsList();
        }
    }
}
