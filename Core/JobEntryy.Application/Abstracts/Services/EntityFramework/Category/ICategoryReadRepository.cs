using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Entities;

namespace JobEntryy.Application.Abstracts.Services.EntityFramework
{
    public interface ICategoryReadRepository : IReadRepository<Category>
    {
    }
}
