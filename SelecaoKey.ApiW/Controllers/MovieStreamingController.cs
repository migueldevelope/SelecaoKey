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
    /// Controller MovieStreaming
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("movieStreaming")]
    public class MovieStreamingController : Controller
    {
        private readonly IServiceMovieStreaming service;

        #region Constructor
        /// <summary>
        /// Construtor controller
        /// </summary>
        /// <param name="_service">Service MovieStreaming</param>
        /// <param name="contextAccessor">Token infomartion</param>
        public MovieStreamingController(IServiceMovieStreaming _service, IHttpContextAccessor contextAccessor)
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
        /// New MovieStreaming
        /// </summary>
        /// <param name="view">View MovieStreaming</param>
        /// <response code="200">Return message: 
        /// MovieStreaming04 - New MovieStreaming success.</response>
        /// <response code="400">Return error code:<br />
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult New([FromBody] ViewCrudMovieStreaming view)
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
        /// Update MovieStreaming
        /// </summary>
        /// <param name="view">View MovieStreaming</param>
        /// <response code="200">Return message: 
        /// MovieStreaming05 - Update MovieStreaming success.</response>
        /// <response code="400">Return error code:<br />
        /// MovieStreaming03 - Id not found.</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ViewCrudMovieStreaming view)
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
        /// Get MovieStreaming to id
        /// </summary>
        /// <param name="id">Identifier MovieStreaming</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewCrudMovieStreaming), StatusCodes.Status200OK)]
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
        /// Delete MovieStreaming to id
        /// </summary>
        /// <param name="id">Identifier MovieStreaming</param>
        /// <response code="200">Return message:
        /// MovieStreaming01 - Deleted MovieStreaming success.</response>
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
        /// List MovieStreamings
        /// </summary>
        /// <param name="filter">Filter name MovieStreaming (optional)</param>
        /// <param name="page">Page to list (optional - Default: 1)</param>
        /// <param name="pageSize">Page size to list (optional - Default: 10)</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(List<ViewCrudMovieStreaming>), StatusCodes.Status200OK)]
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
