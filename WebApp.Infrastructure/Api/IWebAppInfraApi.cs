using WebApp.Infrastructure.Abstractions;

namespace WebApp.Infrastructure.Api
{
    public interface IWebAppInfraApi
    {
        public Task<List<BusinessModel>> GetBusinessModelsAsync(string url);
        public Task<bool> InsertBusinessModelAsync(BusinessViewModel model, string url);
        public Task<bool> UpdateBusinessModelAsync(BusinessModel model, string url);
        public Task<bool> DeleteBusinessModelAsync(int id, string url);


        public Task<List<VisitModel>> GetVisitsAsync(string url);
        public Task<bool> InsertVisitAsync(VisitViewModel model, string url);
        public Task<bool> UpdateVisitAsync(VisitModel model, string url);
        public Task<bool> DeleteVisitAsync(int id, string url);
        public Task<List<VisitModel>> GetVisitsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, string url);
    }
}
