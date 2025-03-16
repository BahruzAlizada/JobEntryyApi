using MediatR;

namespace JobEntryy.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}