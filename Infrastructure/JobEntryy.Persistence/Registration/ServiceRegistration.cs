using System.Data.Common;
using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Persistence.Concrete;
using JobEntryy.Persistence.Services.Dapper;
using JobEntryy.Persistence.Services.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using JobEntryy.Application.Abstracts.ServiceContracts;
using JobEntryy.Persistence.ServiceContracts;

namespace JobEntryy.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddScoped<DbConnection>(provider => new SqlConnection(Context.SqlConnection));

            services.AddScoped<IUserService, UserService>();


            services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();
            services.AddScoped<ICategoryReadDapper,CategoryReadDapper>();
            services.AddScoped<ICategoryWriteDapper,CategoryWriteDapper>();

            services.AddScoped<ICityReadRepository,CityReadRepository>();
            services.AddScoped<ICityWriteRepository,CityWriteRepository>();
            services.AddScoped<ICityReadDapper,CityReadDapper>();
            services.AddScoped<ICityWriteDapper, CityWriteDapper>();

            services.AddScoped<IExperienceReadRepository,ExperienceReadRepository>();
            services.AddScoped<IExperienceWriteRepository,ExperienceWriteRepository>();
            services.AddScoped<IExperienceReadDapper, ExperienceReadDapper>();
            services.AddScoped<IExperienceWriteDapper,ExperienceWriteDapper>();

            services.AddScoped<IIndustryReadRepository,IndustryReadRepository>();
            services.AddScoped<IIndustryWriteRepository,IndustryWriteRepository>();
            services.AddScoped<IIndustryReadDapper,IndustryReadDapper>();
            services.AddScoped<IIndustryWriteDapper, IndustryWriteDapper>();

            services.AddScoped<IJobReadRepository,JobReadRepository>();
            services.AddScoped<IJobWriteRepository,JobWriteRepository>();
            services.AddScoped<IJobReadDapper,JobReadDapper>();
            services.AddScoped<IJobWriteDapper,JobWriteDapper>();

            services.AddScoped<IJobSpamReadRepository,JobSpamReadRepository>();
            services.AddScoped<IJobSpamWriteRepository, JobSpamWriteRepository>();
            services.AddScoped<IJobSpamReadDapper,JobSpamReadDapper>();
            services.AddScoped<IJobSpamWriteDapper,JobSpamWriteDapper>();

            services.AddScoped<IPackageReadRepository,PackageReadRepository>();
            services.AddScoped<IPackageWriteRepository,PackageWriteRepository>();
            services.AddScoped<IPackageReadDapper,PackageReadDapper>();
            services.AddScoped<IPackageWriteDapper, PackageWriteDapper>();

            services.AddScoped<ICompanyReadRepository,CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository,CompanyWriteRepository>();
            services.AddScoped<ICompanyReadDapper,CompanyReadDapper>();
            services.AddScoped<ICompanyWriteDapper, CompanyWriteDapper>();

            services.AddScoped<ICompanyDetailReadRepository, CompanyDetailReadRepository>();
            services.AddScoped<ICompanyDetailWriteRepository,CompanyDetailWriteRepository>();
            services.AddScoped<ICompanyDetailReadDapper, CompanyDetailReadDapper>();
            services.AddScoped<ICompanyDetailWriteDapper,CompanyDetailWriteDapper>();

            services.AddScoped<ICompanySocialMediaReadRepository, CompanySocialMediaReadRepository>();
            services.AddScoped<ICompanySocialMediaWriteRepository, CompanySocialMediaWriteRepository>();
            services.AddScoped<ICompanySocialMediaReadDapper, CompanySocialMediaReadDapper>();
            services.AddScoped<ICompanySocialMediaWriteDapper, CompanySocialMediaWriteDapper>();
        }
    }
}