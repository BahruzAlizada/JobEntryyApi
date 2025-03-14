using FluentValidation;
using JobEntryy.Application.Features.Commands.Category.UpdateCategory;

namespace JobEntryy.Application.Validations.FluentValidation.CategoryValidator
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kateqoriya id-i boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz");
        }
    }
}
