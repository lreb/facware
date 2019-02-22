using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Contracts.UnitOfWork;

namespace NetCore.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // https://localhost:44302/api/v1.0/Areas
    [ApiController]
    public class AreasController : ControllerBase
    {
        private IUnitOfWork _uow;

        public AreasController(IUnitOfWork repoWrapper)
        {
            _uow = repoWrapper;
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
            return Ok(a);
            //return Ok(new { result = "OK" });
        }
    }
}