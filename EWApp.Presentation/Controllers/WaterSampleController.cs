using EWApp.Presentation.ActionFilters;
using EWApp.Presentation.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;
using Shared.RequestFeatures;
using System.Text.Json;

namespace EWApp.Presentation.Controllers
{
    [Route("api/users/{userId}/watersamples")]
    [ApiController]
    public class WaterSampleController : ControllerBase
    {
        private readonly IServiceManager _services;

        public WaterSampleController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet(Name = "GetWaterSamplesForUser")]
        [HttpHead]
        [Authorize]
        public async Task<IActionResult> GetWaterSamplesForUser(Guid userId, [FromQuery] WaterSampleParameters waterSampleParameters)
        {
            var result = await _services.WaterSampleService.GetWaterSamplesForUserAsync(userId, waterSampleParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return Ok(result.waterSampleToReturn);
        }

        [HttpGet("{id:guid}", Name = "GetWaterSampleForUser")]
        public async Task<IActionResult> GetWaterSampleForUser(Guid userId, Guid id)
        {
            var waterSample = await _services.WaterSampleService.GetWaterSampleForUserAsync(userId, id, trackChanges: false);

            return Ok(waterSample);
        }

        [HttpGet("collection/{ids}", Name = "GetWaterSamplesByIdsForUser")]
        public async Task<IActionResult> GetPollsByIdsForUser(Guid userId, [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var waterSampleToReturn = await _services.WaterSampleService.GetWaterSampleByIdsForUserAsync(userId, ids, trackChanges: false);

            return Ok(waterSampleToReturn);
        }

        [HttpPost(Name = "CreateWaterSample")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateWaterSampleForUser(Guid userId, [FromBody] WaterSampleForCreationDto waterSampleForCreation)
        {
            var waterSampleToReturn = await _services.WaterSampleService.CreateWaterSampleForUserAsync(userId, waterSampleForCreation);

            return CreatedAtRoute("GetWaterSampleForUser", new { userId, id = waterSampleToReturn.Id }, waterSampleToReturn);
        }

        [HttpPost("collection", Name = "CreateWaterSampleCollectionForUser")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateWaterSampleCollectionForUser(Guid userId, [FromBody] IEnumerable<WaterSampleForCreationDto> waterSamplesForCreation)
        {
            var result = await _services.WaterSampleService.CreateWaterSampleCollectionForUserAsync(userId, waterSamplesForCreation);

            return CreatedAtRoute("GetWaterSamplesByIdsForUser", new { userId, result.ids }, result.waterSampleToReturn);
        }

        [HttpPut("{id:guid}", Name = "UpdateWaterSampleForUser")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateWaterSampleForUser(Guid userId, Guid id, WaterSampleForUpdateDto waterSampleForUpdate)
        {
            await _services.WaterSampleService.UpdateWaterSampleForUserAsync(userId, id, waterSampleForUpdate, waterSampleTrackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteWaterSampleForUser")]
        public async Task<IActionResult> DeleteWaterSampleForUser(Guid userId, Guid id)
        {
            await _services.WaterSampleService.DeleteWaterSampleForUserAsync(userId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{id:guid}", Name = "PartiallyUpdateWaterSampleForUser")]
        public async Task<IActionResult> PartiallyUpdateWaterSampleForUser(Guid userId, Guid id, [FromBody] JsonPatchDocument<WaterSampleForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("The patchDoc sent by the client is null.");

            var result = await _services.WaterSampleService.GetWaterSampleForPatchAsync(userId, id, waterSampleTrackChanges: true);

            patchDoc.ApplyTo(result.waterSampleForPatch, ModelState);

            TryValidateModel(result.waterSampleForPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.WaterSampleService.SaveChangesForPatchAsync(result.waterSampleForPatch, result.waterSampleEntity);

            return NoContent();
        }

        [HttpOptions(Name = "GetWaterSampleOptions")]
        public IActionResult GetWaterSampleOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, PATCH, HEAD, OPTIONS");

            return Ok();
        }
    }
}
