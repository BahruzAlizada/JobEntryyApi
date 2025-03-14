using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class JobReadRepository : ReadRepository<Job>, IJobReadRepository
    {
        public JobReadRepository(Context context) : base(context)
        {
        }
    }
}
