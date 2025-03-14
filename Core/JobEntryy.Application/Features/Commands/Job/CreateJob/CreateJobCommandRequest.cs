using JobEntryy.Domain.Enums;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Job.CreateJob
{
    public class CreateJobCommandRequest : IRequest<CreateJobCommandResponse>
    {
        public string Name { get; set; }
        public bool IsSalaryHidden { get; set; }
        public int Salary { get; set; }


        public JobType JobType { get; set; }
        public WorkMode? WorkMode { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public EducationLevel? EducationLevel { get; set; }


        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid ExperienceId { get; set; }


        public string? Email { get; set; }
        public string? Link { get; set; }


        public string RequiredSkills { get; set; }
        public string Responsibilities { get; set; }
        public string? JobGraphics { get; set; }

    }
}
