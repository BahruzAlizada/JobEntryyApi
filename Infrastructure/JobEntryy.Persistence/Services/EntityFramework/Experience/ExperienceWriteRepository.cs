using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class ExperienceWriteRepository : WriteRepository<Experience>, IExperienceWriteRepository
    {
        public ExperienceWriteRepository(Context context) : base(context)
        {
        }
    }
}
