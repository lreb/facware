using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Contracts.Logger;
using NetCore.Contracts.UnitOfWork;

namespace NetCore.API.Controllers.V1
{
    /// <summary>
    /// Shopfloor areas
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // https://localhost:44302/api/v1.0/Areas
    [Authorize]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private IUnitOfWork _uow;
        private ILoggerManager _log;

        public AreasController(IUnitOfWork repoWrapper, ILoggerManager log)
        {
            _uow = repoWrapper;
            _log = log;
        }

        // GET api/values
        /// <summary>
        /// Return all areas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var a = _uow.Area.FindAll();
            _log.LogTrace("Get all areas");
            return Ok(a);
            //return Ok(new { result = "OK" });
        }
    }
}