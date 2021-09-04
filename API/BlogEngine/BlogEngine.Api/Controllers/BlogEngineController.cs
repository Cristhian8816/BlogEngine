// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;
    using BlogEngine.Api.Filters;
    using BlogEngine.Business.Interfaces;
    using BlogEngine.Entities.Model;

    /// <summary>
    /// Here goes all the controllers fot the BlogEngine Entity.
    /// </summary>
    [Authorize]
    [RequiredScope("tasks.Authentication")]    
    [Route("api/[controller]/")]
    [ServiceFilter(typeof(TokenValidate))]
    public class BlogEngineController : BaseController
    {
        /// <summary>
        /// BlogEngineBusiness Interface.
        /// </summary>
        private readonly IBlogEngineBusiness _managerBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controllers"/>
        /// </summary>
        /// <param name="managerBusiness"></param>
        public BlogEngineController(IBlogEngineBusiness managerBusiness)
        {
            _managerBusiness = managerBusiness;
        }

        /// <summary>
        /// Get all the items from the entity.
        /// </summary>
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetList();
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Get an item by its id from the entity.
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        /// </summary>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetById")]
        public IActionResult GetById(
        EntityPrimaryKey objectGetById)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetById(objectGetById);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Delete an Item by its id.
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        /// </summary>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpDelete("Delete")]
        public IActionResult Delete(
        EntityPrimaryKey objectDelete)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.Delete(objectDelete);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Insert an item into the entity.
        /// </summary>
        /// <param name="objectInsert"></param>
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] BlogEngineInsertRequest objectInsert)
        {
            UsersAuthenticated userAuthenticated= this.UsersAuthenticated;
            EntityResponse<BlogEngine> response = _managerBusiness.Insert(objectInsert, userAuthenticated);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Update an item from the entity.
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] BlogEngine objectUpdate)
        {
            UsersAuthenticated userAuthenticated = this.UsersAuthenticated;
            EntityResponse<BlogEngine> response = _managerBusiness.Update(objectUpdate, userAuthenticated);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Get the List depending on the paramaters sent.
        ///   </summary>
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetListByParams")]
        public IActionResult GetListByParams(BlogEngineGetListByParams objectGetListByParams)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetListByParams(objectGetListByParams);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Get all the items from the entity with pagination.
        /// </summary>
        /// <returns>BlogEngineResponse.</returns>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetListOrdered")]
        public IActionResult GetListOrdered(EntityGetListOrdered objectGetListOrdered)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetListOrdered(objectGetListOrdered);
            return StatusCode(response.ResponseCode, response);
        }


        /// <summary>
        /// Get an item by its foreignKey from the entity.
        /// </summary>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetByProfileId")]
        public IActionResult GetByProfileId(int ProfileId)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetByFK_BlogEngine_Profiles(ProfileId);
            return StatusCode(response.ResponseCode, response);
        }

        /// <summary>
        /// Get an item by its foreignKey from the entity.
        /// </summary>
        /// <response code="200">Succesfully.</response>
        /// <response code="400">Bad Request.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Request Forbidden.</response>
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.Forbidden)]
        [Produces("application/json", Type = typeof(BlogEngine))]
        [HttpGet("GetByBlogEngineTypeId")]
        public IActionResult GetByBlogEngineTypeId(int BlogEngineTypesId)
        {
            EntityResponse<BlogEngine> response = _managerBusiness.GetByFK_BlogEngine_Profiles(BlogEngineTypesId);
            return StatusCode(response.ResponseCode, response);
        }

    }
}
