using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class ExperienceReadRepository : ReadRepository<Experience>, IExperienceReadRepository
    {
        public ExperienceReadRepository(Context context) : base(context)
        {
        }
    }
}
