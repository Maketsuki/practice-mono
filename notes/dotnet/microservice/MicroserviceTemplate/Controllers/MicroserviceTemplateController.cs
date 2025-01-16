using MicroserviceTemplate.Domain.DTO.Thing;
using MicroserviceTemplate.Infrastructure.ActionFilters;
using MicroserviceTemplate.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace MicroserviceTemplate.Controllers
{
    /// <summary>
    /// This is the controller class for this microservice.
    /// </summary>
    /// <remarks>
    /// <para>
    /// ApiController - attribute adds several things under the hood. If you are using more than one controller, you should consider setting the attribute in
    /// BaseApiController. This can also be added on assembly (Program.cs).
    /// </para>
    /// <para>
    /// Use version in your API URLs. For naming, check REST API naming guide: https://restfulapi.net/resource-naming/
    /// </para>
    /// </remarks>
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class MicroserviceTemplateController : BaseApiController
    {
        private readonly IMicroserviceTemplateManager _microserviceTemplateManager;

        public MicroserviceTemplateController(IMicroserviceTemplateManager microserviceTemplateManager)
        {
            this._microserviceTemplateManager = microserviceTemplateManager;
        }

        /// <summary>
        /// Creates a new Thing with given data, saves the file into database.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [TypeFilter(typeof(UnitOfWorkAttribute))]
        [ProducesResponseType(typeof(ThingReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ThingCreateDto dto)
        {
            ThingReturnDto createdThing = await this._microserviceTemplateManager.CreateNewThing(dto);

            return Ok(createdThing);
        }

        /// <summary>
        /// Gets the Thing from the database
        /// </summary>
        /// <param name="guid">Guid of the Thing</param>
        /// <returns></returns>
        [HttpGet("{guid?}")]
        [ProducesResponseType(typeof(ThingReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] Guid guid)
        {
            ThingReturnDto thing = await this._microserviceTemplateManager.GetThing(guid);
            return Ok(thing);
        }

        /// <summary>
        /// Deletes the given Thing from database
        /// </summary>
        /// <param name="guid">Guid of the Thing</param>
        /// <returns></returns>
        [HttpDelete("{guid?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid)
        {
            await this._microserviceTemplateManager.DeleteThing(guid);

            return Ok();
        }
    }
}