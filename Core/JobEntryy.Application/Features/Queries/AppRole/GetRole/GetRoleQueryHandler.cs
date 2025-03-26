using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Queries.AppRole.GetRole
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQueryRequest, GetRoleQueryResponse>
    {
        private readonly RoleManager<Domain.Identity.AppRole> roleManager;
        public GetRoleQueryHandler(RoleManager<Domain.Identity.AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<GetRoleQueryResponse> Handle(GetRoleQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Identity.AppRole? role = await roleManager.FindByIdAsync(request.Id.ToString());
            if(role == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            RoleDto roleDto = role.Adapt<RoleDto>();
            return new() { Role = roleDto, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
