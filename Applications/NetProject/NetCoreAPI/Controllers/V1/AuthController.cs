using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore.Contract.Logger;
using NetCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreAPI.Controllers.V1
{
    //[ApiVersion("1.0")]
    //[Route("api/{v:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private ILoggerManager _logger;

        public AuthController(ILoggerManager logger)
        {
            _logger = logger;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogTrace("Here is trace message from our values controller.");
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");
            _logger.LogFatal("fail log");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost, Route("login")]
        public IActionResult Post([FromBody]Account user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.AccountID == "1421574" && user.Password == "1421574")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    //new Claim((System.IO.BinaryReader)ClaimTypes.Name, user.PersonID),
                    //new Claim(ClaimTypes.Role, "Administrator"),
                    //new Claim(ClaimTypes.Email, "email@jabil.com"),
                    new Claim("s","s"),
                    new Claim(ClaimTypes.Role,""),
                    new Claim(ClaimTypes.Email, "")
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
