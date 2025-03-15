using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Application.Rules.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntryy.Application.Registration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRuleService,CategoryRuleService>();
            services.AddScoped<ICityRuleService,CityRuleService>();
            services.AddScoped<IExperienceRuleService,ExperienceRuleService>();
            services.AddScoped<IIndustryRuleService,IndustryRuleService>();
            services.AddScoped<IJobRuleService, JobRuleService>();
            services.AddScoped<IPackageRuleService,PackageRuleService>();
        }
    }
}
