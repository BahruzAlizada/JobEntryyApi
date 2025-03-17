using JobEntryy.Application.Abstracts.Services.Dapper;
using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Persistence.Services.Dapper;
using JobEntryy.Persistence.Services.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntryy.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
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

            services.AddScoped<IJobReadRepository,JobReadRepository>();
            services.AddScoped<IJobWriteRepository,JobWriteRepository>();

            services.AddScoped<IPackageReadRepository,PackageReadRepository>();
            services.AddScoped<IPackageWriteRepository,PackageWriteRepository>();
            services.AddScoped<IPackageReadDapper,PackageReadDapper>();
            services.AddScoped<IPackageWriteDapper, PackageWriteDapper>();
        }
    }
}