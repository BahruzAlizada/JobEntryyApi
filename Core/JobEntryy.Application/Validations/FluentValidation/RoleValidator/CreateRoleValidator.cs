using FluentValidation;
using JobEntryy.Application.Features.Commands.AppRole.CreateRole;

namespace JobEntryy.Application.Validations.FluentValidation.RoleValidator
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rol adı boş ola bilməz");
        }
    }
}
