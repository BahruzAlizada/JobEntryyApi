using FluentValidation;
using JobEntryy.Application.Features.Commands.City.CreateCity;

namespace JobEntryy.Application.Validations.FluentValidation.CityValidator
{
    public class CreateCityValidator : AbstractValidator<CreateCityCommandRequest>
    {
        public CreateCityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şəhər adı boş ola bilməz");
        }
    }
}
