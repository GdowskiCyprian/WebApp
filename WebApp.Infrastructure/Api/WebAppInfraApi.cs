using System.Net.Http.Json;
using WebApp.Infrastructure.Abstractions;
using WebApp.Infrastructure.Api.HttpClients;
using WebApp.Infrastructure.Api.HttpClients.Enums;

namespace WebApp.Infrastructure.Api
{
    public class WebAppInfraApi : IWebAppInfraApi
    {
        private readonly IWebAppInfraHttpClient _webAppInfraHttpClient;

        public WebAppInfraApi(IWebAppInfraHttpClient webAppInfraHttpClient)
        {
            _webAppInfraHttpClient = webAppInfraHttpClient;
        }

        public async Task<List<BusinessModel>> GetBusinessModelsAsync(string url)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, url);
                //_httpClient.DefaultRequestHeaders.Add("auth", $"Bearer {token}");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var resp = await _httpClient.GetAsync($"{url}{ApiEndpoints.GetBusinessModels}");
                var content = await resp.Content.ReadAsStringAsync();
                var response = await _httpClient.GetFromJsonAsync<List<BusinessModel>>($"{url}{ApiEndpoints.GetBusinessModels}");
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching business models", ex);
            }
        }

        public async Task<bool> InsertBusinessModelAsync(BusinessViewModel model, string url)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Bearer", await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, url));
                var response = await _httpClient.PostAsJsonAsync($"{url}{ApiEndpoints.InsertBusinessModels}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error inserting business model", ex);
            }
        }

        public async Task<bool> UpdateBusinessModelAsync(BusinessModel model, string url)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Bearer", await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, url));
                var response = await _httpClient.PutAsJsonAsync($"{url}{ApiEndpoints.UpdateBusinessModels}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error updating business model", ex);
            }
        }

        public async Task<bool> DeleteBusinessModelAsync(int id, string url)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("Bearer", await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, url));
                var response = await _httpClient.DeleteAsync($"{url}{ApiEndpoints.GetBusinessModels}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting business model", ex);
            }
        }
    }
}
