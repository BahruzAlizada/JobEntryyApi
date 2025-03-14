using JobEntryy.Application.Abstracts.Services.EntityFramework;
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
        }
    }
}