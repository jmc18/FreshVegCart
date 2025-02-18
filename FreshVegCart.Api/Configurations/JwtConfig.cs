namespace FreshVegCart.Api.Configurations
{
    public class JwtConfig
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; } = 720;
    }
}
