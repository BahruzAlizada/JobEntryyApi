using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Domain.Identity;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Commands.AppRole.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly RoleManager<Domain.Identity.AppRole> roleManager;
        private readonly IRoleRuleService roleRuleService;
        public CreateRoleCommandHandler(RoleManager<Domain.Identity.AppRole> roleManager, IRoleRuleService roleRuleService)
        {
            this.roleManager = roleManager;
            this.roleRuleService = roleRuleService;
        }


        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(roleRuleService.CheckNameIfExisted(request.Name));
            if (!result.Success) return new() { Result = result };
                      
            Domain.Identity.AppRole role = request.Adapt<Domain.Identity.AppRole>();

            await roleManager.CreateAsync(role);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
