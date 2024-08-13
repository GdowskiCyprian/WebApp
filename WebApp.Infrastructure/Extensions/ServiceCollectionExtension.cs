using Microsoft.Extensions.DependencyInjection;
using WebApp.Infrastructure.Api;
using WebApp.Infrastructure.Api.HttpClients;

namespace WebApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddWebAppInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IWebAppInfraHttpClient, WebAppInfraHttpClient>();
            services.AddTransient<IWebAppInfraApi, WebAppInfraApi>();
            return services;
        }
    }
}
