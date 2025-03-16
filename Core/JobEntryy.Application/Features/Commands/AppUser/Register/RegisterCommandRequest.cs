using JobEntryy.Domain.Enums;
using MediatR;

namespace JobEntryy.Application.Features.Commands.AppUser.Register
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        

        public UserType UserType { get; set; }
    }
}