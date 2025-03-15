using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.DeletePackage
{
    public class DeletePackageCommandRequest : IRequest<DeletePackageCommandResponse>
    {
        public Guid Id { get; set; }
    }
}