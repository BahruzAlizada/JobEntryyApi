using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Commands.AppRole.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly RoleManager<Domain.Identity.AppRole> roleManager;
        private readonly IRoleRuleService roleRuleService;
        public UpdateRoleCommandHandler(RoleManager<Domain.Identity.AppRole> roleManager, IRoleRuleService roleRuleService)
        {
            this.roleManager = roleManager;
            this.roleRuleService = roleRuleService;
        }


        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Identity.AppRole? role = await roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            var result = BusinessRules.Run(roleRuleService.CheckNameIfExisted(request.Name, request.Id));
            if (!result.Success) return new() { Result = result };

            role.Name = request.Name;
            role.NormalizedName = request.Name.ToUpper();

            await roleManager.UpdateAsync(role);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
