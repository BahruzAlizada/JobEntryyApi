using FluentValidation;
using JobEntryy.Application.Features.Commands.Experience.UpdateExperience;

namespace JobEntryy.Application.Validations.FluentValidation.ExperienceValidator
{
    public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceCommandRequest>
    {
        public UpdateExperienceValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Təcrübə id-i boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Təcrübə adı boş ola bilməz");
        }
    }
}
