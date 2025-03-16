using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Commands.AppUser.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly UserManager<Domain.Identity.AppUser> userManager;
        public RegisterCommandHandler(UserManager<Domain.Identity.AppUser> userManager)
        {
            this.userManager = userManager;
        }



        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Identity.AppUser user = new()
            {
                Name = request.Name,
                Email = request.Email,
                UserType = request.UserType,
                UserName = Guid.NewGuid().ToString("N").Substring(0, 8),
                JobCount = 0
            };
            
            IdentityResult result = await userManager.CreateAsync(user,request.Password);
            if (!result.Succeeded)
            {
                string errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                return new() { Result = ErrorResult.Create(errorMessages) };
            }

            return new() { Result = SuccessResult.Create(Messages.SuccessRegister) };
        }
    }
}
