using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.CreatePackage
{
    public class CreatePackageCommandRequest : IRequest<CreatePackageCommandResponse>
    {
        public string Name { get; set; }
        public int PremiumJobCount { get; set; }
        public int Price { get; set; }
    }
}