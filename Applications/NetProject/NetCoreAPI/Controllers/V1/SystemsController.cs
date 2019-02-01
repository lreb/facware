using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.Contract.Logger;

namespace NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : Controller
    {
        private ILoggerManager _logger;

        public SystemsController(ILoggerManager logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogTrace("Here is trace message from our values controller.");
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");
            _logger.LogFatal("fail log");
            // _logger.LogInformation(1987, "Getting item {ID}", 3);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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