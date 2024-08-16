namespace WebApp.Infrastructure.Api.HttpClients.Enums
{
    public static class ApiEndpoints
    {
        public static string JwtAuthorization = "/api/Auth/login";
        public static string GetBusinessModels = "/GetBusinessModels";
        public static string InsertBusinessModel = "/InsertBusinessModel";
        public static string UpdateBusinessModel = "/UpdateBusinessModel";
        public static string DeleteBusinessModel = "/DeleteBusinessModel";

        public static string GetVisits = "/GetVisits";
        public static string InsertVisit = "/InsertVisit";
        public static string UpdateVisit = "/UpdateVisit";
        public static string DeleteVisit = "/DeleteVisit";

        public const string GetVisitsByDateRange = "/GetVisitsByDateRange";
    }
}
