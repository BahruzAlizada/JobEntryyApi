using JobEntryy.Application.Abstracts.Caching;
using JobEntryy.Infrastructure.Services.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntryy.Infrastructure.Registration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddScoped<ICacheService,MemoryCacheService>();
        }
    }
}
