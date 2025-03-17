using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Category.GetCachedCategoriesWithJobCount
{
    public class GetCachedCategoriesWithJobCountQueryHandler : IRequestHandler<GetCachedCategoriesWithJobCountQueryRequest, GetCachedCategoriesWithJobCountQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetCachedCategoriesWithJobCountQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }


        public async Task<GetCachedCategoriesWithJobCountQueryResponse> Handle(GetCachedCategoriesWithJobCountQueryRequest request, CancellationToken cancellationToken)
        {
            List<CategoryWithJobCountDto> categories = await categoryReadDapper.GetCachedCategoriesWithJobCount();
            return new() { Categories = categories, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
