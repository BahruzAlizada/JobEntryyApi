using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Features.Commands.Package.CreatePackage;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Package.UpdatePackage
{
    public class UpdatePackageCommandHandler : IRequestHandler<UpdatePackageCommandRequest, UpdatePackageCommandResponse>
    {
        private readonly IPackageWriteRepository packageWriteRepository;
        private readonly IPackageRuleService packageRuleService;
        public UpdatePackageCommandHandler(IPackageWriteRepository packageWriteRepository, IPackageRuleService packageRuleService)
        {
            this.packageWriteRepository = packageWriteRepository;
            this.packageRuleService = packageRuleService;
        }


        public async Task<UpdatePackageCommandResponse> Handle(UpdatePackageCommandRequest request, CancellationToken cancellationToken)
        {
            var result = CheckBusinessRules(request);
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Package package = request.Adapt<Domain.Entities.Package>();
            await packageWriteRepository.UpdateAndSaveAsync(package);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }



        private Result CheckBusinessRules(UpdatePackageCommandRequest request)
        {
            var result = BusinessRules.Run
            (
                packageRuleService.CheckNameIfExist(request.Name,request.Id),
                packageRuleService.CheckPremiumJobCount(request.PremiumJobCount),
                packageRuleService.CheckPrice(request.Price)
            );

            return result;
        }
    }
}
