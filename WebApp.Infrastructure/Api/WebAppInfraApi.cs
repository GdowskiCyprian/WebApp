using System.Net.Http.Json;
using WebApp.Infrastructure.Abstractions;
using WebApp.Infrastructure.Api.HttpClients;
using WebApp.Infrastructure.Api.HttpClients.Enums;
using Microsoft.Extensions.Logging;

namespace WebApp.Infrastructure.Api
{
    public class WebAppInfraApi : IWebAppInfraApi
    {
        private readonly IWebAppInfraHttpClient _webAppInfraHttpClient;
        private readonly HttpClient _httpClient;
        private readonly string _backendUrl;
        private readonly ILogger<WebAppInfraApi> _logger;

        public WebAppInfraApi(IWebAppInfraHttpClient webAppInfraHttpClient, HttpClient httpClient, string backendUrl, ILogger<WebAppInfraApi> logger)
        {
            _webAppInfraHttpClient = webAppInfraHttpClient;
            _httpClient = httpClient;
            _backendUrl = backendUrl;
            _logger = logger;
        }

        private async Task AuthenticateAsync()
        {
            var token = await _webAppInfraHttpClient.GetJwtBearerToken(
                new HttpClients.Models.LoginModel { Username = "testuser", Password = "testpassword" }, _backendUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<BusinessModel>> GetBusinessModelsAsync(int offset = 0)
        {
            try
            {
                await AuthenticateAsync();
                return await _httpClient.GetFromJsonAsync<List<BusinessModel>>(
                    $"{_backendUrl}{ApiEndpoints.GetBusinessModels}?offset={offset}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching business models at offset {offset}", offset);
                return new List<BusinessModel>();
            }
        }

        public async Task<bool> InsertBusinessModelAsync(BusinessViewModel model)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}{ApiEndpoints.InsertBusinessModel}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error inserting business model: {model}", model);
                return false;
            }
        }

        public async Task<bool> UpdateBusinessModelAsync(BusinessModel model)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}{ApiEndpoints.UpdateBusinessModel}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error updating business model: {model}", model);
                return false;
            }
        }

        public async Task<bool> DeleteBusinessModelAsync(int id)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.DeleteAsync($"{_backendUrl}{ApiEndpoints.DeleteBusinessModel}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error deleting business model with Id {id}", id);
                return false;
            }
        }

        // Visit Methods
        public async Task<List<VisitModel>> GetVisitsAsync(int offset = 0)
        {
            try
            {
                await AuthenticateAsync();
                return await _httpClient.GetFromJsonAsync<List<VisitModel>>(
                    $"{_backendUrl}{ApiEndpoints.GetVisits}?offset={offset}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching visits at offset {offset}", offset);
                return new List<VisitModel>();
            }
        }

        public async Task<bool> InsertVisitAsync(VisitViewModel model)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.PostAsJsonAsync($"{_backendUrl}{ApiEndpoints.InsertVisit}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error inserting visit: {model}", model);
                return false;
            }
        }

        public async Task<bool> UpdateVisitAsync(VisitModel model)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.PutAsJsonAsync($"{_backendUrl}{ApiEndpoints.UpdateVisit}", model);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error updating visit: {model}", model);
                return false;
            }
        }

        public async Task<bool> DeleteVisitAsync(int id)
        {
            try
            {
                await AuthenticateAsync();
                var response = await _httpClient.DeleteAsync($"{_backendUrl}{ApiEndpoints.DeleteVisit}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error deleting visit with Id {id}", id);
                return false;
            }
        }

        public async Task<List<VisitModel>> GetVisitsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, int offset = 0)
        {
            try
            {
                await AuthenticateAsync();
                return await _httpClient.GetFromJsonAsync<List<VisitModel>>(
                    $"{_backendUrl}{ApiEndpoints.GetVisitsByDateRange}?dateFrom={dateFrom:yyyy-MM-dd}&dateTo={dateTo:yyyy-MM-dd}&offset={offset}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching visits by date range: {dateFrom} to {dateTo}", dateFrom, dateTo);
                return new List<VisitModel>();
            }
        }
    }
}