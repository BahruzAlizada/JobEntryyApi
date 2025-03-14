﻿using JobEntryy.Application.Abstracts.Services.EntityFramework;
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

            services.AddScoped<ICityReadRepository,CityReadRepository>();
            services.AddScoped<ICityWriteRepository,CityWriteRepository>();

            services.AddScoped<IExperienceReadRepository,ExperienceReadRepository>();
            services.AddScoped<IExperienceWriteRepository,ExperienceWriteRepository>();

            services.AddScoped<IIndustryReadRepository,IndustryReadRepository>();
            services.AddScoped<IIndustryWriteRepository,IndustryWriteRepository>();

            services.AddScoped<IPackageReadRepository,PackageReadRepository>();
            services.AddScoped<IPackageWriteRepository,PackageWriteRepository>();
        }
    }
}