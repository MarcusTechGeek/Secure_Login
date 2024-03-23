using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace SecureLogin.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IConfiguration _configuration;

        public CustomAuthenticationStateProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Implementation to decode JWT and validate here.
            // This is a placeholder, you need to replace it with actual JWT decoding logic.
            var identity = new ClaimsIdentity();
            try
            {
                // Example: Extract the token from a cookie or the current HttpContext,
                // decode it, validate it, and set the identity based on the token's claims.
            }
            catch
            {
                identity = new ClaimsIdentity(); // Unauthenticated identity if JWT is invalid
            }

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
