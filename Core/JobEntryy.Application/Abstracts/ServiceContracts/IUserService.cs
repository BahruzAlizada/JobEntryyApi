using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts.ServiceContracts
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUser(Guid id);
    }
}
