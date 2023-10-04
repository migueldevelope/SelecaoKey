using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using SelecaoKey.Core.Interfaces;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;

namespace SelecaoKey.Api.Controllers
{
    /// <summary>
    /// Controller Movie
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("movie")]
    public class MovieController : Controller
    {
        private readonly IServiceMovie service;

        #region Constructor
        /// <summary>
        /// Construtor controller
        /// </summary>
        /// <param name="_service">Service Movie</param>
        /// <param name="contextAccessor">Token infomartion</param>
        public MovieController(IServiceMovie _service, IHttpContextAccessor contextAccessor)
        {
            try
            {
                service = _service;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Crud

        /// <summary>
        /// New Movie
        /// </summary>
        /// <param name="view">View Movie</param>
        /// <response code="200">Return message: 
        /// Movie04 - New Movie success.</response>
        /// <response code="400">Return error code:<br />
        /// Movie02 - Name invalid.<br />
        /// Movie03 - Company invalid.</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult New([FromBody] ViewCrudMovie view)
        {
            try
            {
                return Ok(service.New(view));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="view">View Movie</param>
        /// <response code="200">Return message: 
        /// Movie06 - Update Movie success.</response>
        /// <response code="400">Return error code:<br />
        /// Movie02 - Name invalid.<br />
        /// Movie03 - Company invalid. <br />
        /// Movie05 - Id not found.</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ViewCrudMovie view)
        {
            try
            {
                return Ok(service.Update(view));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get Movie to id
        /// </summary>
        /// <param name="id">Identifier Movie</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewCrudMovie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Delete Movie to id
        /// </summary>
        /// <param name="id">Identifier Movie</param>
        /// <response code="200">Return message:
        /// Movie01 - Deleted Movie success.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// List Movies
        /// </summary>
        /// <param name="filter">Filter name Movie (optional)</param>
        /// <param name="page">Page to list (optional - Default: 1)</param>
        /// <param name="pageSize">Page size to list (optional - Default: 10)</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(List<ViewCrudMovie>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Get(int pageSize = 10, int page = 1, string filter = "")
        {
            try
            {
                return Ok(service.List(pageSize, page, filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion

    }
}
