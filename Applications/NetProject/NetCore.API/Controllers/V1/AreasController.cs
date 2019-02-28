using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contract.Utility.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Contracts.Logger;
using NetCore.Contracts.UnitOfWork;
using NetCore.Data.Access.DataAccessModels.Dashboards;

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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repoWrapper">Unit of work service</param>
        /// <param name="log">logger service</param>
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
            try
            {
                var areas = _uow.Area.FindAll();
                if (areas == null)
                {
                    _log.LogWarn($"areas not found");
                    return NotFound(new TransactionResult(Result.WARNING, "AREAS_NOT_FOUND"));
                }
                return Ok(new TransactionResult(Result.SUCCESS, "SUCCESS", areas));
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Enabled")]
        public IActionResult GetEnabled()
        {
            try
            {
                var areas = _uow.Area.FindByCondition(x=>x.Enabled == true);
                if (areas == null)
                {
                    _log.LogWarn($"areas not found");
                    return NotFound(new TransactionResult(Result.WARNING, "AREAS_NOT_FOUND"));
                }
                return Ok(new TransactionResult(Result.SUCCESS, "SUCCESS", areas));
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// Example to retun sp
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("WithSP")]
        public IActionResult GetWithSP()
        {
            try
            {
                var sp = _uow.StoreProcedure.TestSp();
                return Ok(new TransactionResult(Result.SUCCESS, "SUCCESS", sp));
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// Get area by id
        /// </summary>
        /// <param name="id">area id</param>
        /// <returns>one area</returns>
        [HttpGet("{id}", Name = "GetArea")]
        public IActionResult GetAreaById(long id)
        {
            try
            {
                var area = _uow.Area.GetById(id);
                if (area == null)
                {
                    _log.LogWarn($"areas not found");
                    return NotFound(new TransactionResult(Result.WARNING, "NOT_FOUND", id));
                }
                return Ok(new TransactionResult(Result.SUCCESS,"SUCCESS",area));
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// Create new area
        /// </summary>
        /// <param name="area">area model</param>
        /// <returns>area created</returns>
        [HttpPost]
        public IActionResult Create([FromBody]Areas area)
        {
            try
            {
                if (area == null)
                {
                    _log.LogWarn($"areas not found");
                    return BadRequest(new TransactionResult(Result.WARNING, "AREA_NULL", area));
                }
                if (!ModelState.IsValid)
                {
                    _log.LogError($"Model invalid: {area}");
                    return BadRequest(new TransactionResult(Result.WARNING, "INVALID_AREA", area));
                }
                _uow.Area.Create(area);
                _uow.Area.Save();
                return CreatedAtRoute( routeName: "GetArea", routeValues: new { id = area.Id}, value: area);
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }    
        }
        /// <summary>
        /// CreateArea and properties
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpPost, Route("WithTransaction")]
        public IActionResult CreateWithProperties(Areas area)
        {
            try
            {
                _uow.AreasPropertiesService.Create(area);
                return CreatedAtRoute(routeName: "GetArea", routeValues: new { id = area.Id }, value: area);
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// Update area
        /// </summary>
        /// <param name="id">area id to update</param>
        /// <param name="area">new area data</param>
        /// <returns>area updated</returns>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Areas area)
        {
            try
            {
                if (area == null)
                {
                    _log.LogWarn($"areas not found");
                    return BadRequest(new TransactionResult(Result.WARNING, "AREA_NULL", area));
                }
                if (!ModelState.IsValid)
                {
                    _log.LogError($"Model invalid: {area}");
                    return BadRequest(new TransactionResult(Result.WARNING, "INVALID_AREA", area));
                }
                var dbArea = _uow.Area.GetById(id);
                if (area == null)
                {
                    _log.LogWarn($"areasdb not found");
                    return NotFound(new TransactionResult(Result.WARNING, "AREA_NULL", area));
                }
                _uow.Area.CompareAndUpdate(dbArea, area);
                // _uow.Area.Update(area);
                // _uow.Area.Save();

                return CreatedAtRoute(routeName: "GetArea", routeValues: new { id = id }, value: area);
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
        /// <summary>
        /// Delete area
        /// </summary>
        /// <param name="id">area id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var dbArea = _uow.Area.GetById(id);
                if (dbArea == null)
                {
                    _log.LogWarn($"areasdb not found");
                    return NotFound(new TransactionResult(Result.WARNING, "AREA_NULL", dbArea));
                }
                _uow.Area.LogicalDelete(dbArea);
                return Ok(new TransactionResult(Result.SUCCESS, "RECORD_DELETED"));
            }
            catch (Exception e)
            {
                _log.LogFatal($"{typeof(AreasController)} : {e.Message} ");
                return StatusCode(500, new TransactionResult(Result.ERROR, $"{typeof(AreasController)} : {e.Message}", e));
            }
        }
    }
}