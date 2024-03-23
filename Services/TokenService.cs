using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;

namespace SecureLogin.Services
{
    public class TokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IHttpContextAccessor httpContextAccessor, ILogger<TokenService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        // Get decoded JWT token.
        public string GetDecodedToken()
        {
            var jwtToken = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            if (string.IsNullOrEmpty(jwtToken))
            {
                _logger.LogWarning("No JWT token found in session.");
                return "No token found";
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);
                return Newtonsoft.Json.JsonConvert.SerializeObject(token.Payload, Newtonsoft.Json.Formatting.Indented);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error decoding JWT token.");
                return "Invalid token";
            }
        }
    }
}
