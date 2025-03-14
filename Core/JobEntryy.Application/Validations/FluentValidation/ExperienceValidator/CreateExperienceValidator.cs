using FluentValidation;
using JobEntryy.Application.Features.Commands.City.CreateCity;
using JobEntryy.Application.Features.Commands.Experience.CreateExperience;

namespace JobEntryy.Application.Validations.FluentValidation.ExperienceValidator
{
    public class CreateExperienceValidator : AbstractValidator<CreateExperienceCommandRequest>
    {
        public CreateExperienceValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Təcrübə adı boş ola bilməz");
        }
    }
}
