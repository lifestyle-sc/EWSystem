﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class WaterSampleRepository : RepositoryBase<WaterSample>, IWaterSampleRepository
    {
        public WaterSampleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateWaterSampleForUser(Guid userId, WaterSample waterSample)
        {
            waterSample.UserId = userId.ToString();
            waterSample.CreatedAt = DateTime.UtcNow;
            waterSample.UpdatedAt = DateTime.UtcNow;
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
    }
}
