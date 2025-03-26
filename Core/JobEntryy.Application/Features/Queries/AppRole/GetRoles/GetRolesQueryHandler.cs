using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Application.Features.Queries.AppRole.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
    {
        private readonly RoleManager<Domain.Identity.AppRole> roleManager;
        public GetRolesQueryHandler(RoleManager<Domain.Identity.AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Identity.AppRole> roles = await roleManager.Roles.ToListAsync();
            List<RoleDto> roleDtos = roles.Adapt<List<RoleDto>>();

            return new() { Roles = roleDtos, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
