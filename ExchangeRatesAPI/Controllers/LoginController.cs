using ExchangeRatesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExchangeRatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuth _auth;

        public LoginController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpGet("getToken")]
        public ActionResult<string> GetToken(string? UserName = "planetgreen", string? Password = "password")
        {
            try
            {   //please note this is just for demo purpose, logic has not been implemented to authenticate user from database
                var user = new
                {
                    UserId = "knjsd34kbsdfd234dsf",
                    UserName = "planetgreen",
                    Password = "password"
                };

                //create a service to verify the credentials and return the user id if exists
                if (true)//if user exists
                {
                    var token = _auth.NewToken(user.UserId);
                    return StatusCode(200, token);
                }
                else
                {
                    throw new UnauthorizedAccessException("User does not exists, Please Register.");
                }
            }
            catch (UnauthorizedAccessException) { throw; }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
