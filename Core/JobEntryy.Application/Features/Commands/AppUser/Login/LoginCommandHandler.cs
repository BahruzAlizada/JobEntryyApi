using JobEntryy.Application.Abstracts;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Exceptions;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JobEntryy.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<Domain.Identity.AppUser> userManager;
        private readonly SignInManager<Domain.Identity.AppUser> signInManager;
        private readonly ITokenHandler tokenHandler;
        public LoginCommandHandler(UserManager<Domain.Identity.AppUser> userManager, SignInManager<Domain.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
        }


        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Identity.AppUser? user = await userManager.FindByEmailAsync(request.Email) ?? throw new UserNotFoundException();
            if (!user.Status) return new() { Result = ErrorResult.Create("This Account's Status deactivited") };

            var result = await signInManager.PasswordSignInAsync(user, request.Password,true,true);
            if (!result.Succeeded) return new() { Result = ErrorResult.Create("Fail when Login Account") };

            TokenDto tokenDto = tokenHandler.CreateAccessToken(5);
            user.RefreshToken = tokenDto.RefreshToken;
            user.RefreshTokenEndDate = tokenDto.Expiration.AddMinutes(30);

            await userManager.UpdateAsync(user);

            return new() { Token = tokenDto, Result = SuccessResult.Create(Messages.SuccessLogin) };
        }
    }
}
