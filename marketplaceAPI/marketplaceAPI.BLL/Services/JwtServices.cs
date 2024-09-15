using marketplaceAPI.BLL.DTOs.AuthModels;
using marketplaceAPI.BLL.DTOs.UtilsModels;
using marketplaceAPI.BLL.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace marketplaceAPI.BLL.Services
{
    public class JwtServices : IJwtService
    {
        private readonly JWTConfig _jwtOptions;
        public JwtServices(IOptions<JWTConfig> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
        }

        public string GenerateToken(UserDTO user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var secret = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
            var security = new SymmetricSecurityKey(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationTimeMinutes),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token =  tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
