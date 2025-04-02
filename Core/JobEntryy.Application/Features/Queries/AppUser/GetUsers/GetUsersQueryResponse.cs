using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.AppUser.GetUsers
{
    public class GetUsersQueryResponse
    {
        public Result Result { get; set; }
        public List<UserDto> Users { get; set; }
    }
}