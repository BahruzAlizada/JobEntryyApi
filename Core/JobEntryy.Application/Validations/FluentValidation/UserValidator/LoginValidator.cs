using FluentValidation;
using JobEntryy.Application.Features.Commands.AppUser.Login;

namespace JobEntryy.Application.Validations.FluentValidation.UserValidator
{
    public class LoginValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email adresini düzgün daxil etmək lazımdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə boş ola bilməz");
        }
    }
}
