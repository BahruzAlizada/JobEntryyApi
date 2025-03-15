using FluentValidation;
using JobEntryy.Application.Features.Commands.Package.UpdatePackage;

namespace JobEntryy.Application.Validations.FluentValidation.PackageValidator
{
    public class UpdatePackageValidator : AbstractValidator<UpdatePackageCommandRequest>
    {
        public UpdatePackageValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Paket id-i boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Paket adı boş ola bilməz");
        }
    }
}
