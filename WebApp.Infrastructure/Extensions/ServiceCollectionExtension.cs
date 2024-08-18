using Microsoft.Extensions.DependencyInjection;
using WebApp.Infrastructure.Api;
using WebApp.Infrastructure.Api.HttpClients;

namespace WebApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddWebAppInfrastructure(this IServiceCollection services, string url)
        {
            services.AddTransient<IWebAppInfraHttpClient, WebAppInfraHttpClient>();
            services.AddTransient<IWebAppInfraApi>(s =>
            {
                return new WebAppInfraApi((IWebAppInfraHttpClient)s.GetRequiredService(typeof(IWebAppInfraHttpClient)),url);
            });
            return services;
        }
    }
}
