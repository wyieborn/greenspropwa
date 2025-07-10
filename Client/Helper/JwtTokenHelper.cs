
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    namespace GreensProCPWA.Client.Helpers
    {
        public static class JwtTokenHelper
        {
            public static ClaimsPrincipal ParseClaimsFromJwt(string jwt)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);

                var identity = new ClaimsIdentity(token.Claims, "jwt");
                return new ClaimsPrincipal(identity);
            }
        }
    }

