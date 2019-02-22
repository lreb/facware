using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.API.Controllers.V1
{
    /// <summary>
    /// Shifts for the factory
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // https://localhost:44302/api/v1.0/Areas
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
    }
}