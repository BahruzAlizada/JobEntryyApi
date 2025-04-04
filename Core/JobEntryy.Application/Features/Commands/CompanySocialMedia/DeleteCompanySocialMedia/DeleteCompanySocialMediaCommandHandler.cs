using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.CompanySocialMedia.DeleteCompanySocialMedia
{
    public class DeleteCompanySocialMediaCommandHandler : IRequestHandler<DeleteCompanySocialMediaCommandRequest, DeleteCompanySocialMediaCommandResponse>
    {
        private readonly ICompanySocialMediaWriteRepository companySocialMediaWriteRepository;
        public DeleteCompanySocialMediaCommandHandler(ICompanySocialMediaWriteRepository companySocialMediaWriteRepository)
        {
            this.companySocialMediaWriteRepository = companySocialMediaWriteRepository;
        }



        public async Task<DeleteCompanySocialMediaCommandResponse> Handle(DeleteCompanySocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            await companySocialMediaWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
