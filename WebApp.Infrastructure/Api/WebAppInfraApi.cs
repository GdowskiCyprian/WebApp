using System.Net.Http.Json;
using WebApp.Infrastructure.Abstractions;
using WebApp.Infrastructure.Api.HttpClients;
using WebApp.Infrastructure.Api.HttpClients.Enums;

namespace WebApp.Infrastructure.Api
{
    public class WebAppInfraApi : IWebAppInfraApi
    {
        private readonly IWebAppInfraHttpClient _webAppInfraHttpClient;
        private readonly string _backendUrl;

        public WebAppInfraApi(IWebAppInfraHttpClient webAppInfraHttpClient, string backendUrl)
        {
            _webAppInfraHttpClient = webAppInfraHttpClient;
            _backendUrl = backendUrl;
        }

        public async Task<List<BusinessModel>> GetBusinessModelsAsync()
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var resp = await _httpClient.GetAsync($"{_backendUrl}{ApiEndpoints.GetBusinessModels}");
                var content = await resp.Content.ReadAsStringAsync();
                var response = await _httpClient.GetFromJsonAsync<List<BusinessModel>>($"{_backendUrl}{ApiEndpoints.GetBusinessModels}");
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching business models", ex);
            }
        }

        public async Task<bool> InsertBusinessModelAsync(BusinessViewModel model)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}{ApiEndpoints.InsertBusinessModel}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error inserting business model", ex);
            }
        }

        public async Task<bool> UpdateBusinessModelAsync(BusinessModel model)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}{ApiEndpoints.UpdateBusinessModel}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error updating business model", ex);
            }
        }

        public async Task<bool> DeleteBusinessModelAsync(int id)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.DeleteAsync($"{_backendUrl}{ApiEndpoints.DeleteBusinessModel}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting business model", ex);
            }
        }

        // Visit Methods
        public async Task<List<VisitModel>> GetVisitsAsync()
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<VisitModel>>($"{_backendUrl}{ApiEndpoints.GetVisits}");
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching visits", ex);
            }
        }

        public async Task<bool> InsertVisitAsync(VisitViewModel model)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl));
                var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}{ApiEndpoints.InsertVisit}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error inserting visit", ex);
            }
        }

        public async Task<bool> UpdateVisitAsync(VisitModel model)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}{ApiEndpoints.UpdateVisit}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error updating visit", ex);
            }
        }

        public async Task<bool> DeleteVisitAsync(int id)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl));
                var response = await _httpClient.DeleteAsync($"{_backendUrl}{ApiEndpoints.DeleteVisit}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error deleting visit", ex);
            }
        }

        public async Task<List<VisitModel>> GetVisitsByDateRangeAsync(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                var token = await _webAppInfraHttpClient.GetJwtBearerToken(new HttpClients.Models.LoginModel() { Username = "testuser", Password = "testpassword" }, _backendUrl);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<VisitModel>>($"{_backendUrl}{ApiEndpoints.GetVisitsByDateRange}?dateFrom={dateFrom:yyyy-MM-dd}&dateTo={dateTo:yyyy-MM-dd}");
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching visits by date range", ex);
            }
        }
    }
}
