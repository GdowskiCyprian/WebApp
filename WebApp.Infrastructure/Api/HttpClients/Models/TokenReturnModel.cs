using System.Text.Json.Serialization;

namespace WebApp.Infrastructure.Api.HttpClients.Models
{
    public class TokenReturnModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
