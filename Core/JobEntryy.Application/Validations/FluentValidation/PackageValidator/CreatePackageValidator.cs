using FluentValidation;
using JobEntryy.Application.Features.Commands.Package.CreatePackage;

namespace JobEntryy.Application.Validations.FluentValidation.PackageValidator
{
    public class CreatePackageValidator : AbstractValidator<CreatePackageCommandRequest>
    {
        public CreatePackageValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Paket adı boş ola bilməz");
        }
    }
}
