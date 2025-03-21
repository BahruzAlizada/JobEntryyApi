using FluentValidation;
using JobEntryy.Application.Features.Commands.Job.SetJobPremium;

namespace JobEntryy.Application.Validations.FluentValidation.JobValidator
{
    public class SetJobPremiumValidator : AbstractValidator<SetJobPremiumCommandRequest>
    {
        public SetJobPremiumValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty().WithMessage("İstifadəçi id-i boş ola bilməz");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("Vakansiya id-i boş ola bilməz");
        }
    }
}
