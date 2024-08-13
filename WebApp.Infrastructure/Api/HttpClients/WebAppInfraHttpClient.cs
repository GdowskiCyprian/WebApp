using System.Net.Http.Json;
using System.Text.Json;
using WebApp.Infrastructure.Api.HttpClients.Enums;
using WebApp.Infrastructure.Api.HttpClients.Models;

namespace WebApp.Infrastructure.Api.HttpClients
{
    public class WebAppInfraHttpClient : IWebAppInfraHttpClient
    {

        public WebAppInfraHttpClient()
        {
        }

        public async Task<string> GetJwtBearerToken(LoginModel loginModel, string url)
        {
            HttpClient _httpClient = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Post;
            message.Content = JsonContent.Create<LoginModel>(loginModel);
            message.RequestUri = new Uri($"{url}{ApiEndpoints.JwtAuthorization}");

            var response = await _httpClient.SendAsync(message);

            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TokenReturnModel>(responseContent, new JsonSerializerOptions() { }).Token;
        }
    }
}
