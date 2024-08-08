using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IWaterSampleRepository
    {
        void CreateWaterSampleForUser(Guid userId, WaterSample waterSample);

        Task<PagedList<WaterSample>> GetWaterSamplesForUserAsync(Guid userId, WaterSampleParameters waterSampleParameters, bool trackChanges);

        Task<WaterSample> GetWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges);

        Task<IEnumerable<WaterSample>> GetWaterSampleByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges);

        void UpdateWaterSampleForUser(WaterSample waterSample);

        void DeleteWaterSampleForUser(WaterSample waterSample);
    }
}
