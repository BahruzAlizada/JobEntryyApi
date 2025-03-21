using System.Reflection;
using FluentValidation;
using JobEntryy.Application.Behaviors;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Application.Rules.Concrete;
using JobEntryy.Application.Validations.FluentValidation.CategoryValidator;
using JobEntryy.Application.Validations.FluentValidation.CityValidator;
using JobEntryy.Application.Validations.FluentValidation.ExperienceValidator;
using JobEntryy.Application.Validations.FluentValidation.IndustryValidator;
using JobEntryy.Application.Validations.FluentValidation.PackageValidator;
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

            services.AddScoped<ICategoryRuleService,CategoryRuleService>();
            services.AddScoped<ICityRuleService,CityRuleService>();
            services.AddScoped<IExperienceRuleService,ExperienceRuleService>();
            services.AddScoped<IIndustryRuleService,IndustryRuleService>();
            services.AddScoped<IJobRuleService, JobRuleService>();
            services.AddScoped<IPackageRuleService,PackageRuleService>();


            services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCityValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCityValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateExperienceValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateIndustryValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateIndustryValidator>();
            services.AddValidatorsFromAssemblyContaining<CreatePackageValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePackageValidator>();
        }
    }
}
