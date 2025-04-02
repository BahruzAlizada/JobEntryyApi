using System.Reflection;
using FluentValidation;
using JobEntryy.Application.Behaviors;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Application.Rules.Concrete;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntryy.Application.Registration
{
    public static class ServiceRegistration 
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(typeof(ServiceRegistration));

            var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            config.Compile();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            services.AddValidationServices();


            services.AddScoped<ICategoryRuleService,CategoryRuleService>();
            services.AddScoped<ICityRuleService,CityRuleService>();
            services.AddScoped<IExperienceRuleService,ExperienceRuleService>();
            services.AddScoped<IIndustryRuleService,IndustryRuleService>();
            services.AddScoped<IJobRuleService, JobRuleService>();
            services.AddScoped<IJobSpamRuleService, JobSpamRuleService>();
            services.AddScoped<IPackageRuleService,PackageRuleService>();
            services.AddScoped<IRoleRuleService, RoleRuleService>();
        }
    }
}
