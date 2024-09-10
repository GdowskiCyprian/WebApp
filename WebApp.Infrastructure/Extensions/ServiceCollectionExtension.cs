using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                return new WebAppInfraApi((IWebAppInfraHttpClient)s.GetRequiredService(typeof(IWebAppInfraHttpClient)), new HttpClient(), url, (ILogger<WebAppInfraApi>)s.GetRequiredService(typeof(ILogger<WebAppInfraApi>)));
            });
            return services;
        }
    }
}
