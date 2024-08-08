using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class WaterSampleRepository : RepositoryBase<WaterSample>, IWaterSampleRepository
    {
        private DateTime startDate = new DateTime(2023, 11, 1);
        public WaterSampleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateWaterSampleForUser(Guid userId, WaterSample waterSample)
        {
            waterSample.UserId = userId.ToString();
            waterSample.CreatedAt = GetRandomDays(startDate, DateTime.UtcNow);
            waterSample.UpdatedAt = waterSample.CreatedAt;
            Create(waterSample);
        }

        public void DeleteWaterSampleForUser(WaterSample waterSample)
        {
            Delete(waterSample);
        }

        public async Task<IEnumerable<WaterSample>> GetWaterSampleByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges)
        {
            var waterSamples = await FindByCondition(p => p.UserId == userId.ToString() && ids.Contains(p.Id), trackChanges)
            .ToListAsync();

            return waterSamples;
        }

        public async Task<WaterSample> GetWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var waterSample = await FindByCondition(p => p.UserId == userId.ToString() && p.Id == id, trackChanges)
                .SingleOrDefaultAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return waterSample;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<PagedList<WaterSample>> GetWaterSamplesForUserAsync(Guid userId, WaterSampleParameters waterSampleParameters, bool trackChanges)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var waterSamples = await FindByCondition(p => p.UserId == userId.ToString(), trackChanges)
                .Search(waterSampleParameters.SearchTerm)
                .Sort(waterSampleParameters.OrderBy)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return PagedList<WaterSample>.ToPagedList(waterSamples, waterSampleParameters.PageNumber, waterSampleParameters.PageSize);
        }

        public void UpdateWaterSampleForUser(WaterSample waterSample)
        {
            waterSample.UpdatedAt = DateTime.UtcNow;
            Update(waterSample);
        }

        private DateTime GetRandomDays(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();

            int range = (endDate - startDate).Days;

            return startDate.AddDays(random.Next(range))
                            .AddHours(random.Next(0, 24))
                            .AddMinutes(random.Next(0, 60))
                            .AddSeconds(random.Next(0, 60));
        }
    }
}
