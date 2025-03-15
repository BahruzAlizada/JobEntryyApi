using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.UpdatePackage
{
    public class UpdatePackageCommandRequest : IRequest<UpdatePackageCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PremiumJobCount { get; set; }
        public int Price { get; set; }
    }
}