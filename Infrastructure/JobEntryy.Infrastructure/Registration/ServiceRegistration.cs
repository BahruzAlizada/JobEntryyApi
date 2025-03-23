using JobEntryy.Application.Abstracts;
using JobEntryy.Application.Abstracts.Caching;
using JobEntryy.Infrastructure.Services;
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
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
