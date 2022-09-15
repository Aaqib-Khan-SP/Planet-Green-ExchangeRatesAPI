using System.Security.Claims;

namespace ExchangeRatesAPI.Models
{
    public interface IAuth
    {
        public string NewToken(string userId);
        public ClaimsPrincipal VerifyToken(string token);
        public string UserIdFromToken(string token);
    }
}
