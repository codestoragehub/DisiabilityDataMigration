using System.Text.Json.Serialization;

namespace DisabilityInPortal.Domain.Models.Reports;

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public string ExpiresIn { get; set; }

    [JsonPropertyName("ext_expires_in")]
    public string ExtExpiresIn { get; set; }

    [JsonPropertyName("expires_on")]
    public string ExpiresOn { get; set; }

    [JsonPropertyName("not_before")]
    public string NotBefore { get; set; }

    [JsonPropertyName("resource")]
    public string Resource { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    [JsonPropertyName("id_token")]
    public string IdToken { get; set; }
}