using FluentValidation;
using JobEntryy.Application.Features.Commands.Industry.CreateIndustry;

namespace JobEntryy.Application.Validations.FluentValidation.IndustryValidator
{
    public class CreateIndustryValidator : AbstractValidator<CreateIndustryCommandRequest>
    {
        public CreateIndustryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Sənaye adı boş ola bilməz");  
        }
    }
}
