using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
        }


        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(categoryRuleService.CheckNameIfExist(request.Name, request.Id));
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Category category = request.Adapt<Domain.Entities.Category>();
            await categoryWriteRepository.UpdateAndSaveAsync(category);
            return new() { Result = SuccessResult.Create(Messages.SuccessUpdated) };
        }
    }
}
