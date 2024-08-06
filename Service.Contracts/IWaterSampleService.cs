using Entities.Models;
using Shared.DTOs;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IWaterSampleService
    {
        Task<WaterSampleDto> CreateWaterSampleForUserAsync(Guid userId, WaterSampleForCreationDto waterSampleForCreation);

        Task<(IEnumerable<WaterSampleDto> waterSampleToReturn, MetaData metaData)> GetWaterSamplesForUserAsync(Guid userId, WaterSampleParameters waterSampleParameters, bool trackChanges);

        Task<WaterSampleDto> GetWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges);

        Task<IEnumerable<WaterSampleDto>> GetWaterSampleByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges);

        Task<(IEnumerable<WaterSampleDto> waterSampleToReturn, string ids)> CreateWaterSampleCollectionForUserAsync(Guid userId, IEnumerable<WaterSampleForCreationDto> waterSampleForCreation);

        Task DeleteWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges);

        Task UpdateWaterSampleForUserAsync(Guid userId, Guid id, WaterSampleForUpdateDto waterSampleForUpdate, bool waterSampleTrackChanges);

        Task<(WaterSampleForUpdateDto waterSampleForPatch, WaterSample waterSampleEntity)> GetWaterSampleForPatchAsync(Guid userId, Guid id, bool waterSampleTrackChanges);

        Task SaveChangesForPatchAsync(WaterSampleForUpdateDto waterSampleForPatch, WaterSample waterSampleEntity);
    }
}
