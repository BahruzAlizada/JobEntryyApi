using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryResponse
    {
        public Result Result { get; set; }
        public UserDto? User { get; set; }
    }
}