using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Category.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetCategoryQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }


        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            CategoryDto? category = await categoryReadDapper.GetCategory(request.Id);
            if (category == null) return new() { Result = ErrorResult.Create(Messages.IdNull) };

            return new() { Category = category, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
