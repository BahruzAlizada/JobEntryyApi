using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.AppRole.GetRole
{
    public class GetRoleQueryResponse
    {
        public Result Result { get; set; }
        public RoleDto? Role { get; set; }
    }
}