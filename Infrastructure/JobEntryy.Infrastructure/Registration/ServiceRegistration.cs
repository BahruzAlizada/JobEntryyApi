using JobEntryy.Application.Abstracts;
using JobEntryy.Application.Abstracts.Caching;
using JobEntryy.Infrastructure.Services;
using JobEntryy.Infrastructure.Services.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace JobEntryy.Infrastructure.Registration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IElasticClient>(new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200"))));
            services.AddScoped(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));


            services.AddScoped<ICacheService,MemoryCacheService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
