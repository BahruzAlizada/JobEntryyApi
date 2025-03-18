using System.Data;
using FluentValidation;
using JobEntryy.Application.Features.Commands.AppUser.Register;

namespace JobEntryy.Application.Validations.FluentValidation.UserValidator
{
    public class RegisterValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email adresini düzgün daxil etmək lazımdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə boş ola bilməz");
            RuleFor(x => x.CheckPassword).NotEmpty().WithMessage("Şifrə boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş ola bilməz");
            RuleFor(x => x.UserType).NotEmpty().WithMessage("İstifadəçi tipi boş qala bilməz");
        }
    }
}
