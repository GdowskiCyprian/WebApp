using WebApp.Infrastructure.Abstractions;

namespace WebApp.Infrastructure.Api
{
    public interface IWebAppInfraApi
    {
        public Task<List<BusinessModel>> GetBusinessModelsAsync(string url);
        public Task<bool> InsertBusinessModelAsync(BusinessViewModel model, string url);
        public Task<bool> UpdateBusinessModelAsync(BusinessModel model, string url);
        public Task<bool> DeleteBusinessModelAsync(int id, string url);
    }
}
