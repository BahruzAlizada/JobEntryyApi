using MediatR;

namespace JobEntryy.Application.Features.Commands.AppRole.DeleteRole
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public Guid Id { get; set; }    
    }
}
