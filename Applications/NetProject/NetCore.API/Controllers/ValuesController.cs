using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Contracts.UnitOfWork;

namespace NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUnitOfWork _uow;

        public ValuesController(IUnitOfWork repoWrapper)
        {
            _uow = repoWrapper;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var a = _uow.Account.FindAll();
            return Ok(a);
        }

        /*[HttpPost, Route("login")]
        public IActionResult Post([FromBody]Account user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.AccountReference == "1421574" && user.Password == "1421574")
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
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
