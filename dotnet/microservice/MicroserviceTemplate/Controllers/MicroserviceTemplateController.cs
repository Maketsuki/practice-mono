using MicroserviceTemplate.Domain.DTO.Thing;
using MicroserviceTemplate.Infrastructure.ActionFilters;
using MicroserviceTemplate.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
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
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        [MapToApiVersion("1.0")]
        [TypeFilter(typeof(UnitOfWorkAttribute))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThingReturnDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IResult> Post([FromBody] ThingCreateDto dto)
        {
            if (dto is null) return Results.BadRequest("Invalid input");
            ThingReturnDto createdThing = await this._microserviceTemplateManager.CreateNewThing(dto);
            return createdThing is not null ? Results.Ok(createdThing) : Results.UnprocessableEntity();
        }

        /// <summary>
        /// Gets the Thing from the database
        /// </summary>
        /// <param name="guid">Guid of the Thing</param>
        /// <returns></returns>
        [HttpGet("{guid:guid?}")]
        [MapToApiVersion("1.0")]
        [OutputCache(Duration = 60)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThingReturnDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IResult> Get([FromRoute] Guid? guid = null)
        {
            if (guid is null) return Results.BadRequest("GUID is required");
            ThingReturnDto thing = await this._microserviceTemplateManager.GetThing(guid.Value);
            return thing is not null ? Results.Ok(thing) : Results.NotFound();
        }

        /// <summary>
        /// Deletes the given Thing from database
        /// </summary>
        /// <param name="guid">Guid of the Thing</param>
        /// <returns></returns>
        [HttpDelete("{guid:guid?}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IResult> Delete([FromRoute] Guid? guid = null)
        {

            if (guid is null) return Results.BadRequest("GUID is required");
            await this._microserviceTemplateManager.DeleteThing(guid.Value);
            return Results.Ok();
        }
    }
}