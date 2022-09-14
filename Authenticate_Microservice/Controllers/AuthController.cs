using Authenticaticate_Microservice.Model;
using Authenticaticate_Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authenticaticate_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        public AuthController()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        }
        [HttpPost]
        public IActionResult Post([FromBody] User u)
        {
            _log4net.Info("Login method generated");
            UserRep uL = new UserRep();
            var userList = uL.getUserList();
            foreach (var v in userList)
            {
                if (u.UserId == v.UserId && u.Password == v.Password)
                {
                    string role = "";
                    if (u.Role == "Employee")
                        role = "Employee";
                    else
                        role = "Customer";
                    var result = new
                    {
                        token = GenerateJSONWebToken(u.UserId, role)
                    };
                    _log4net.Info("Token Generated");
                    return Ok(result);
                }
            }
            _log4net.Info("Token Denied");
            return BadRequest();
        }
        private string GenerateJSONWebToken(long userId, string userRole)
        {
            _log4net.Info("Token Generation Initiated");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Role, userRole),

                new Claim("UserId", userId.ToString())

            };

            var token = new JwtSecurityToken(

            issuer: "mySystem",

            audience: "myUsers",

            claims: claims,

            expires: DateTime.Now.AddMinutes(10),

            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
