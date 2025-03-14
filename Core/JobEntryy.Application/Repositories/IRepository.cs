using JobEntryy.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
