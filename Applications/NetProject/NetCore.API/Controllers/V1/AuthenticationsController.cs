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
using NetCore.Contracts.Logger;
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
        private ILoggerManager _log;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uow">Unit of work service</param>
        /// <param name="log">logger service</param>
        public AuthenticationsController(IUnitOfWork uow, ILoggerManager log)
        {
            this._uow = uow;
            _log = log;
        }
        /// <summary>
        /// Create ne user session
        /// </summary>
        /// <param name="user">user data to authneticate</param>
        /// <returns>JWT</returns>
        [AllowAnonymous]
        [HttpPost, Route("Login")]
        public IActionResult Create(Users user)
        {
            try
            {
                if (user == null)
                    return BadRequest(new TransactionResult(Result.ERROR, "USER_PASSWORD_INCORRECT", user));
                // query if the user is existent
                var dbUser = _uow.User.FindByCondition(x => x.EmployeeId == user.EmployeeId && x.Enabled == true).FirstOrDefault();

                // var result = new TransactionResult(Result.WARNING, "USER_NOT_FOUND", user);

                if (dbUser == null)
                    return NotFound(new TransactionResult(Result.WARNING, "USER_NOT_FOUND", user));

                // hash the password (salt+password) and compare with user hash
                // our awesome function to hash password

                // Is the user and hash match, then generate JWT authentication
                if (user.EmployeeId == dbUser.EmployeeId) // Incomplete, this must be a function "UnitOfWork"
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                {
                    new Claim("UserId", Convert.ToString(dbUser.Id)),
                    new Claim("EmployeeId", dbUser.EmployeeId),
                    new Claim("Role", "Administrator"), // aqui podria ir el rol mi Erik
                    new Claim("Email", dbUser.Email),
                };

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5), // this maybe can be a database variable
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new TransactionResult(Result.SUCCESS, "USER_NOT_FOUND", new { Token = tokenString }));
                }
                else
                {
                    _log.LogWarn($"UNAUTHORIZED_USER : {user}");
                    return Unauthorized(new TransactionResult(Result.ERROR, "UNAUTHORIZED_USER", user));
                }
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} -  {e.InnerException.Message}");
                return StatusCode(500, new TransactionResult(Result.ERROR, e.Message, $"{typeof(AreasController)} : {e.InnerException.Message}"));
            }
        }
    }
}