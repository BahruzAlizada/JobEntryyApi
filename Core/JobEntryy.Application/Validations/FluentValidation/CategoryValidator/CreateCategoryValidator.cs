using FluentValidation;
using JobEntryy.Application.Features.Commands.Category.CreateCategory;

namespace JobEntryy.Application.Validations.FluentValidation.CategoryValidator
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kateqoriya adı boş ola bilməz");
        }
    }
}
