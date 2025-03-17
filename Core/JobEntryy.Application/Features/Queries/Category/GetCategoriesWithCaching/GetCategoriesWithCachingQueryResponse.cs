using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Category.GetCategoriesWithCaching
{
    public class GetCategoriesWithCachingQueryResponse
    {
        public Result Result { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}