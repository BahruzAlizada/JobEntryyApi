using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Commands.AppRole.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly RoleManager<Domain.Identity.AppRole> roleManager;
        public DeleteRoleCommandHandler(RoleManager<Domain.Identity.AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }


        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Identity.AppRole? role = await roleManager.FindByIdAsync(request.Id.ToString());
            if(role==null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            await roleManager.DeleteAsync(role);
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
