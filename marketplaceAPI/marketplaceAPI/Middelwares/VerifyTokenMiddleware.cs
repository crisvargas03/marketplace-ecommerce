using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace marketplaceAPI.Middelwares
{
    public class VerifyTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public VerifyTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");
            if (authHeader is not null && authHeader.Length == 2 && authHeader[0] == "Bearer")
            {
                var token = authHeader[1];
                var handler = new JwtSecurityTokenHandler();

                try
                {
                    var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                    if (jwtToken is not null)
                    {
                        // Verificar la expiración del token
                        if (jwtToken.ValidTo < DateTime.UtcNow)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Token has expired");
                            return;
                        }

                        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
                        var roleIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                        if (!string.IsNullOrEmpty(userIdClaim))
                        {
                            context.Request.Headers.Append("User-Id", userIdClaim);
                        }

                        if (!string.IsNullOrEmpty(roleIdClaim))
                        {
                            context.Request.Headers.Append("Role-Id", roleIdClaim);
                        }
                    }
                }
                catch (SecurityTokenException)
                {
                    // Si el token no es válido
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid token");
                    return;
                }
            }
            await _next(context);
        }
    }
}
