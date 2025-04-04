using FluentValidation;
using JobEntryy.Application.Features.Commands.CompanySocialMedia.CreateCompanySocialMedia;

namespace JobEntryy.Application.Validations.FluentValidation.CompanySocialMedia
{
    public class CreateCompanySocialMediaValidator : AbstractValidator<CreateCompanySocialMediaCommandRequest>
    {
        public CreateCompanySocialMediaValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirkət id-i boş ola bilməz");
            RuleFor(x=>x.Platform).NotEmpty().WithMessage("Platforma boş ola bilməz");
            RuleFor(x=>x.Url).NotEmpty().WithMessage("Url boş ola bilməz");
        }
    }
}
