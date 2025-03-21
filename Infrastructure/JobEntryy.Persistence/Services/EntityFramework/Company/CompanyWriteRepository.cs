using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Exceptions;
using JobEntryy.Domain.Entities;
using JobEntryy.Domain.Identity;
using JobEntryy.Persistence.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Services.EntityFramework
{
    public class CompanyWriteRepository : ICompanyWriteRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Context context;
        public CompanyWriteRepository(UserManager<AppUser> userManager, Context context)
        {
            this.userManager = userManager;
            this.context = context;
        }


        public async Task AssignIndustriesToCompany(Guid companyId, Guid[] industryId)
        {
            AppUser company = await userManager.FindByIdAsync(companyId.ToString()) ?? throw new UserNotFoundException();

            List<CompanyIndustry> companyIndustries = await context.CompanyIndustries.Where(x=>x.UserId==companyId).ToListAsync();
            context.CompanyIndustries.RemoveRange(companyIndustries);

            List<CompanyIndustry> newCompanyIndustries = new List<CompanyIndustry>();
            foreach (var id in industryId)
            {
                Industry? industry = await context.Industries.FindAsync(id);
                if(industry!= null)
                {
                    CompanyIndustry comppanyIndustry = CompanyIndustry.Create(company.Id, industry.Id);
                    newCompanyIndustries.Add(comppanyIndustry);
                }
            }

            await context.CompanyIndustries.AddRangeAsync(newCompanyIndustries);
            await context.SaveChangesAsync();
        }
    }
}
