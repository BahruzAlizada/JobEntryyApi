using FluentValidation;
using JobEntryy.Application.Features.Commands.Industry.UpdateIndustry;

namespace JobEntryy.Application.Validations.FluentValidation.IndustryValidator
{
    public class UpdateIndustryValidator : AbstractValidator<UpdateIndustryCommandRequest>
    {
        public UpdateIndustryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sənaye id-i boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sənaye adı boş ola bilməz");
        }
    }
}
