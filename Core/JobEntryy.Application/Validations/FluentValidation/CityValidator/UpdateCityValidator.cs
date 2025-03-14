using FluentValidation;
using JobEntryy.Application.Features.Commands.City.UpdateCity;

namespace JobEntryy.Application.Validations.FluentValidation.CityValidator
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityCommandRequest>
    {
        public UpdateCityValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Şəhər id-i boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şəhər adı boş ola bilməz");
        }
    }
}
