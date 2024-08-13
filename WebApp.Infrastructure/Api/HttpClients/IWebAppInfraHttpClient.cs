using WebApp.Infrastructure.Api.HttpClients.Models;

namespace WebApp.Infrastructure.Api.HttpClients
{
    public interface IWebAppInfraHttpClient
    {

        public Task<string> GetJwtBearerToken(LoginModel loginModel, string url);
    }
}
