using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules;
using JobEntryy.Application.Rules.Abstract;
using Mapster;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
        }


        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var result = BusinessRules.Run(categoryRuleService.CheckNameIfExist(request.Name));
            if (!result.Success) return new() { Result = result };

            Domain.Entities.Category category = request.Adapt<Domain.Entities.Category>();
            await categoryWriteRepository.AddAndSaveAsync(category);
            return new() { Result = SuccessResult.Create(Messages.SuccessAdded) };
        }
    }
}
