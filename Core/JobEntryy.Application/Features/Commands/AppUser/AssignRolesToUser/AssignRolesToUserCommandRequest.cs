using MediatR;

namespace JobEntryy.Application.Features.Commands.AppUser.AssignRolesToUser
{
    public class AssignRolesToUserCommandRequest : IRequest<AssignRolesToUserCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid[] RolesIds { get; set; }
    }
}