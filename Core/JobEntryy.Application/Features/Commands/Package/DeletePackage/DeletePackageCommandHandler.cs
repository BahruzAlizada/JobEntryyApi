using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.DeletePackage
{
    public class DeletePackageCommandHandler : IRequestHandler<DeletePackageCommandRequest, DeletePackageCommandResponse>
    {
        private readonly IPackageWriteRepository packageWriteRepository;
        public DeletePackageCommandHandler(IPackageWriteRepository packageWriteRepository)
        {
            this.packageWriteRepository = packageWriteRepository;
        }


        public async Task<DeletePackageCommandResponse> Handle(DeletePackageCommandRequest request, CancellationToken cancellationToken)
        {
            await packageWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
