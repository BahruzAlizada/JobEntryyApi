using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetAllCategoriesQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }



        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            List<CategoryAllDto> categories = await categoryReadDapper.GetAllCategories();
            return new() { Categories = categories, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
