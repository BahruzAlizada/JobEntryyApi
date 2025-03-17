using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Category.GetCachedCategoriesWithJobCount
{
    public class GetCachedCategoriesWithJobCountQueryResponse
    {
        public Result Result { get; set; }
        public List<CategoryWithJobCountDto> Categories { get; set; }
    }
}