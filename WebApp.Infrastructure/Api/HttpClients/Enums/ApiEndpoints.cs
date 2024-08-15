namespace WebApp.Infrastructure.Api.HttpClients.Enums
{
    public static class ApiEndpoints
    {
        public static string JwtAuthorization = "/api/Auth/login";
        public static string GetBusinessModels = "/GetBusinessModels";
        public static string InsertBusinessModels = "/InsertBusinessModels";
        public static string UpdateBusinessModels = "/UpdateBusinessModels";
        public static string DeleteBusinessModels = "/DeleteBusinessModels";

        public static string GetVisits = "/GetVisits";
        public static string InsertVisit = "/InsertVisit";
        public static string UpdateVisit = "/UpdateVisit";
        public static string DeleteVisit = "/DeleteVisit";

        public const string GetVisitsByDateRange = "/GetVisitsByDateRange";
    }
}
