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
    /// Controller Streaming
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("streaming")]
    public class StreamingController : Controller
    {
        private readonly IServiceStreaming service;

        #region Constructor
        /// <summary>
        /// Construtor controller
        /// </summary>
        /// <param name="_service">Service Streaming</param>
        /// <param name="contextAccessor">Token infomartion</param>
        public StreamingController(IServiceStreaming _service, IHttpContextAccessor contextAccessor)
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
        /// New Streaming
        /// </summary>
        /// <param name="view">View Streaming</param>
        /// <response code="200">Return message: 
        /// Streaming04 - New Streaming success.</response>
        /// <response code="400">Return error code:<br />
        /// Streaming02 - Name invalid.<br />
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult New([FromBody] ViewCrudStreaming view)
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
        /// Update Streaming
        /// </summary>
        /// <param name="view">View Streaming</param>
        /// <response code="200">Return message: 
        /// Streaming05 - Update Streaming success.</response>
        /// <response code="400">Return error code:<br />
        /// Streaming02 - Name invalid.<br />
        /// Streaming03 - Id not found.</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ViewCrudStreaming view)
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
        /// Get Streaming to id
        /// </summary>
        /// <param name="id">Identifier Streaming</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewCrudStreaming), StatusCodes.Status200OK)]
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
        /// Delete Streaming to id
        /// </summary>
        /// <param name="id">Identifier Streaming</param>
        /// <response code="200">Return message:
        /// Streaming01 - Deleted Streaming success.</response>
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
        /// List Streamings
        /// </summary>
        /// <param name="filter">Filter name Streaming (optional)</param>
        /// <param name="page">Page to list (optional - Default: 1)</param>
        /// <param name="pageSize">Page size to list (optional - Default: 10)</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(List<ViewCrudStreaming>), StatusCodes.Status200OK)]
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
