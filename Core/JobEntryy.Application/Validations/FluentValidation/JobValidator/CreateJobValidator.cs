using FluentValidation;
using JobEntryy.Application.Features.Commands.Job.CreateJob;

namespace JobEntryy.Application.Validations.FluentValidation.JobValidator
{
    public class CreateJobValidator : AbstractValidator<CreateJobCommandRequest>
    {
        public CreateJobValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İş elanının adı boş ola bilməz");
            RuleFor(x => x.JobType).NotEmpty().WithMessage("İş elanın iş tipi boş ola bilməz");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("İş elanın şirkət id-i boş ola bilməz");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("İş elanın kateqoriya id-i boş ola bilməz");
            RuleFor(x=>x.ExperienceId).NotEmpty().WithMessage("İş elanın təcrübə id-i boş ola bilməz");
            RuleFor(x=>x.Responsibilities).NotEmpty().WithMessage("İş elanın iş məsuliyyətləri boş ola bilməz");
            RuleFor(x=>x.RequiredSkills).NotEmpty().WithMessage("İş elanın tələb olunan bacarıqları boş ola bilməz");
        }
    }
}
