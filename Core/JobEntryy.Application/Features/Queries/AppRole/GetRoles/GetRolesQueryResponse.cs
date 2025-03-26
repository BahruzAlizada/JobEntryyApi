using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.AppRole.GetRoles
{
    public class GetRolesQueryResponse
    {
        public Result Result { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}