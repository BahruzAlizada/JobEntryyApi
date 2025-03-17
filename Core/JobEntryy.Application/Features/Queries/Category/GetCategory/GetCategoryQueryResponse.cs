using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Queries.Category.GetCategory
{
    public class GetCategoryQueryResponse
    {
        public Result Result { get; set; }
        public CategoryDto? Category { get; set; }
    }
}