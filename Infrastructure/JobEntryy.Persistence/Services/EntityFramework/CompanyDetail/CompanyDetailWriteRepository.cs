using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Domain.Entities;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Repositories;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class CompanyDetailWriteRepository : WriteRepository<CompanyDetail>, ICompanyDetailWriteRepository
    {
        public CompanyDetailWriteRepository(Context context) : base(context)
        {
        }
    }
}
