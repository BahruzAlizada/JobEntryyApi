using FluentValidation;
using JobEntryy.Application.Features.Commands.AppRole.UpdateRole;

namespace JobEntryy.Application.Validations.FluentValidation.RoleValidator
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommandRequest>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Rol id boş ola bilməz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rol adı boş ola bilməz");
        }
    }
}
