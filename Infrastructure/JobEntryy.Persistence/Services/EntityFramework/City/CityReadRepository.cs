using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class CityReadRepository : ReadRepository<City>, ICityReadRepository
    {
        public CityReadRepository(Context context) : base(context)
        {
        }
    }
}
