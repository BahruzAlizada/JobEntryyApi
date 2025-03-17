using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Category.GetCategoriesWithCaching
{
    public class GetCategoriesWithCachingQueryHandler : IRequestHandler<GetCategoriesWithCachingQueryRequest, GetCategoriesWithCachingQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetCategoriesWithCachingQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }


        public async Task<GetCategoriesWithCachingQueryResponse> Handle(GetCategoriesWithCachingQueryRequest request, CancellationToken cancellationToken)
        {
            List<CategoryDto> categories = await categoryReadDapper.GetCategoriesWithCaching();
            return new() { Categories = categories, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
