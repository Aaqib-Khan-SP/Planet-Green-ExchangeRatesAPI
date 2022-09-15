using ExchangeRatesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExchangeRatesAPI.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var Auth = (IAuth)context.HttpContext.RequestServices.GetService(typeof(IAuth));
                string token = String.Empty;
                if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value.ToString().Replace("Bearer ", string.Empty);

                    try
                    {
                        var claimPrinciple = Auth.VerifyToken(token);
                    }
                    catch (Exception ex)
                    {
                        context.ModelState.AddModelError("Unauthorized", ex.ToString());
                        context.Result = new UnauthorizedObjectResult(context.ModelState);
                    }
                }
                else
                {
                    throw new Exception("Token Missing");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
