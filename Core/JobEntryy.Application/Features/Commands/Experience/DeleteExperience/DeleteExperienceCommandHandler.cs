using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Experience.DeleteExperience
{
    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommandRequest, DeleteExperienceCommandResponse>
    {
        private readonly IExperienceWriteRepository experienceWriteRepository;
        public DeleteExperienceCommandHandler(IExperienceWriteRepository experienceWriteRepository)
        {
            this.experienceWriteRepository = experienceWriteRepository;
        }


        public async Task<DeleteExperienceCommandResponse> Handle(DeleteExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            await experienceWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
