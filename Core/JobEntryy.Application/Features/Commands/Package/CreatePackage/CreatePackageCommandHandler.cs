using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.CreatePackage
{
    public class CreatePackageCommandHandler : IRequestHandler<CreatePackageCommandRequest, CreatePackageCommandResponse>
    {
        private readonly IPackageWriteRepository packageWriteRepository;
        private readonly IPackageRuleService packageRuleService;
        public CreatePackageCommandHandler(IPackageWriteRepository packageWriteRepository, IPackageRuleService packageRuleService)
        {
            this.packageWriteRepository = packageWriteRepository;
            this.packageRuleService = packageRuleService;
        }


        public async Task<CreatePackageCommandResponse> Handle(CreatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            var result = CheckBusinessRules(request);
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Package package = Domain.Entities.Package.Create(request.Name,request.PremiumJobCount, request.Price);
            await packageWriteRepository.AddAndSaveAsync(package);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
         


        private Result CheckBusinessRules(CreatePackageCommandRequest request)
        {
            var result = BusinessRules.Run
            (
                packageRuleService.CheckNameIfExist(request.Name),
                packageRuleService.CheckPremiumJobCount(request.PremiumJobCount),
                packageRuleService.CheckPrice(request.Price)
            );

            return result;
        }
    }
}
