using FluentValidation;
using JobEntryy.Application.Validations.FluentValidation.CategoryValidator;
using JobEntryy.Application.Validations.FluentValidation.CityValidator;
using JobEntryy.Application.Validations.FluentValidation.ExperienceValidator;
using JobEntryy.Application.Validations.FluentValidation.IndustryValidator;
using JobEntryy.Application.Validations.FluentValidation.JobSpamValidator;
using JobEntryy.Application.Validations.FluentValidation.JobValidator;
using JobEntryy.Application.Validations.FluentValidation.PackageValidator;
using JobEntryy.Application.Validations.FluentValidation.RoleValidator;
using JobEntryy.Application.Validations.FluentValidation.UserValidator;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntryy.Application.Registration
{
    public static class ValidationServiceRegistration
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateCityValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCityValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateExperienceValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateIndustryValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateIndustryValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateIndustryValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateIndustryValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateJobSpamValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateJobValidator>();
            services.AddValidatorsFromAssemblyContaining<SetJobPremiumValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateJobValidator>();

            services.AddValidatorsFromAssemblyContaining<CreatePackageValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePackageValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateRoleValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateRoleValidator>();

            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
        }
    }
}
