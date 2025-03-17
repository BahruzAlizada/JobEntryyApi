using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public Result Result { get; set; }
        public List<CategoryAllDto> Categories { get; set; }
    }
}