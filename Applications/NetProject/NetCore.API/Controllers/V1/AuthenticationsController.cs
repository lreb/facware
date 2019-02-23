using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Contract.Utility.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore.Contracts.UnitOfWork;
using NetCore.Data.Access.DataAccessModels.Dashboards;

namespace NetCore.API.Controllers.V1
{
    /// <summary>
    /// Authentication endpoint
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // https://localhost:44302/api/v1.0/Areas
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private IUnitOfWork _uow;

        public AuthenticationsController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        [AllowAnonymous]
        [HttpPost, Route("Login")]
        public IActionResult Create(Users user)
        {

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (user.EmployeeId == "1421574")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("UserId", Convert.ToString(user.Id)),
                    new Claim("EmployeeId", user.EmployeeId),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new TransactionResult {
                    _success = true,
                    _data = new { Token = tokenString }
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}