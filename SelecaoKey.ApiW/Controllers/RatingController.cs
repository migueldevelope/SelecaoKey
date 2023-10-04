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
    /// Controller Rating
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("rating")]
    public class RatingController : Controller
    {
        private readonly IServiceRating service;

        #region Constructor
        /// <summary>
        /// Construtor controller
        /// </summary>
        /// <param name="_service">Service Rating</param>
        /// <param name="contextAccessor">Token infomartion</param>
        public RatingController(IServiceRating _service, IHttpContextAccessor contextAccessor)
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
        /// New Rating
        /// </summary>
        /// <param name="view">View Rating</param>
        /// <response code="200">Return message: 
        /// Rating04 - New Rating success.</response>
        /// <response code="400">Return error code:<br />
        /// Rating02 - Name invalid.<br />
        /// Rating03 - Company invalid.</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult New([FromBody] ViewCrudRating view)
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
        /// Update Rating
        /// </summary>
        /// <param name="view">View Rating</param>
        /// <response code="200">Return message: 
        /// Rating06 - Update Rating success.</response>
        /// <response code="400">Return error code:<br />
        /// Rating02 - Name invalid.<br />
        /// Rating03 - Company invalid. <br />
        /// Rating05 - Id not found.</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ViewCrudRating view)
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
        /// Get Rating to id
        /// </summary>
        /// <param name="id">Identifier Rating</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewCrudRating), StatusCodes.Status200OK)]
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
        /// Delete Rating to id
        /// </summary>
        /// <param name="id">Identifier Rating</param>
        /// <response code="200">Return message:
        /// Rating01 - Deleted Rating success.</response>
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
        /// List Ratings
        /// </summary>
        /// <param name="filter">Filter name Rating (optional)</param>
        /// <param name="page">Page to list (optional - Default: 1)</param>
        /// <param name="pageSize">Page size to list (optional - Default: 10)</param>
        /// <response code="200">Return information.</response>
        /// <response code="400">Return error code.</response>
        [Authorize]
        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(List<ViewCrudRating>), StatusCodes.Status200OK)]
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
