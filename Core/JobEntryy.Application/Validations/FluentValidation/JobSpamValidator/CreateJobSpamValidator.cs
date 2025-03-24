using FluentValidation;
using JobEntryy.Application.Features.Commands.JobSpam.CreateJobSpam;

namespace JobEntryy.Application.Validations.FluentValidation.JobSpamValidator
{
    public class CreateJobSpamValidator : AbstractValidator<CreateJobSpamCommandRequest>
    {
        public CreateJobSpamValidator()
        {
            RuleFor(x => x.ReportedByEmail).NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email adresini düzgün şəkildə qeyd etmək lazımdır");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("Vakansiya id-i boş ola bilməz");
            RuleFor(x => x.Reason).NotEmpty().WithMessage("Spam səbəbi boş ola bilməz");
        }
    }
}
