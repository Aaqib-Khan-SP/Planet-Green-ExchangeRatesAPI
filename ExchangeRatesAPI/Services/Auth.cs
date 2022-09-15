using ExchangeRatesAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExchangeRatesAPI.Services
{
    public class Auth : IAuth
    {
        private SymmetricSecurityKey _key;
        private JwtSecurityTokenHandler tokenHandler;
        public Auth(SymmetricSecurityKey key)
        {
            _key = key;
            tokenHandler = new JwtSecurityTokenHandler();
        }

        public string NewToken(string userId)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("UserId",userId)
                }),

                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var claims = tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _key,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                },out SecurityToken validateToken);
            return claims;
        }

        public string UserIdFromToken(string token)
        {
            var jwtToken = tokenHandler.ReadJwtToken(token.ToString().Replace("Bearer ",String.Empty));
            var userId = jwtToken.Claims.First(claim => claim.Type =="UserId").Value;
            return userId;
        }

    }
}
