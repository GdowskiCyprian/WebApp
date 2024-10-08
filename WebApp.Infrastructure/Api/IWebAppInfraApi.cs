﻿using WebApp.Infrastructure.Abstractions;

namespace WebApp.Infrastructure.Api
{
    public interface IWebAppInfraApi
    {
        public Task<List<BusinessModel>> GetBusinessModelsAsync(int offset = 0);
        public Task<bool> InsertBusinessModelAsync(BusinessViewModel model);
        public Task<bool> UpdateBusinessModelAsync(BusinessModel model);
        public Task<bool> DeleteBusinessModelAsync(int id);


        public Task<List<VisitModel>> GetVisitsAsync(int offset = 0);
        public Task<bool> InsertVisitAsync(VisitViewModel model);
        public Task<bool> UpdateVisitAsync(VisitModel model);
        public Task<bool> DeleteVisitAsync(int id);
        public Task<List<VisitModel>> GetVisitsByDateRangeAsync(DateTime dateFrom, DateTime dateTo, int offset = 0);
    }
}