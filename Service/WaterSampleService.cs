using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DTOs;
using Shared.RequestFeatures;

namespace Service
{
    public class WaterSampleService : IWaterSampleService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public WaterSampleService(UserManager<User> userManager, IMapper mapper, ILoggerManager logger, IRepositoryManager repository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        private async Task CheckIfUserExistsAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UserNotFoundException(userId);
        }

        private async Task<WaterSample> CheckIfWaterSampleExistsAndReturnItAsync(Guid userId, Guid id, bool trackChanges)
        {
            var waterSample = await _repository.WaterSample.GetWaterSampleForUserAsync(userId, id, trackChanges);

            if (waterSample == null)
                throw new WaterSampleNotFoundException(id);

            return waterSample;
        }

        public async Task<(IEnumerable<WaterSampleDto> waterSampleToReturn, string ids)> CreateWaterSampleCollectionForUserAsync(Guid userId, IEnumerable<WaterSampleForCreationDto> waterSampleForCreation)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSamplesEntity = _mapper.Map<IEnumerable<WaterSample>>(waterSampleForCreation);

            foreach (var waterSample in waterSamplesEntity)
            {
                _repository.WaterSample.CreateWaterSampleForUser(userId, waterSample);
            }

            await _repository.SaveAsync();

            var waterSamplesToReturn = _mapper.Map<IEnumerable<WaterSampleDto>>(waterSamplesEntity);

            var ids = string.Join(",", waterSamplesToReturn.Select(p => p.Id));

            return (waterSamplesToReturn, ids);
        }

        public async Task<WaterSampleDto> CreateWaterSampleForUserAsync(Guid userId, WaterSampleForCreationDto waterSampleForCreation)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSample = _mapper.Map<WaterSample>(waterSampleForCreation);

            _repository.WaterSample.CreateWaterSampleForUser(userId, waterSample);

            await _repository.SaveAsync();

            var waterSampleToReturn = _mapper.Map<WaterSampleDto>(waterSample);

            return waterSampleToReturn;
        }

        public async Task DeleteWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSampleEntity = await CheckIfWaterSampleExistsAndReturnItAsync(userId, id, trackChanges);

            _repository.WaterSample.DeleteWaterSampleForUser(waterSampleEntity);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<WaterSampleDto>> GetWaterSampleByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            if (ids == null)
                throw new IdsParameterBadRequest();

            var waterSampleEntities = await _repository.WaterSample.GetWaterSampleByIdsForUserAsync(userId, ids, trackChanges);

            if (waterSampleEntities.Count() != ids.Count())
                throw new CollectionByIdsBadRequest();

            var waterSampleToReturn = _mapper.Map<IEnumerable<WaterSampleDto>>(waterSampleEntities);

            return waterSampleToReturn;
        }

        public async Task<(WaterSampleForUpdateDto waterSampleForPatch, WaterSample waterSampleEntity)> GetWaterSampleForPatchAsync(Guid userId, Guid id, bool waterSampleTrackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSampleEntity = await CheckIfWaterSampleExistsAndReturnItAsync(userId, id, waterSampleTrackChanges);

            var waterSampleForPatch = _mapper.Map<WaterSampleForUpdateDto>(waterSampleEntity);

            return (waterSampleForPatch, waterSampleEntity);
        }

        public async Task<WaterSampleDto> GetWaterSampleForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSample = await CheckIfWaterSampleExistsAndReturnItAsync(userId, id, trackChanges);

            var waterSampleToReturn = _mapper.Map<WaterSampleDto>(waterSample);

            return waterSampleToReturn;
        }

        public async Task<(IEnumerable<WaterSampleDto> waterSampleToReturn, MetaData metaData)> GetWaterSamplesForUserAsync(Guid userId, WaterSampleParameters waterSampleParameters, bool trackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSamplesWithMetaData = await _repository.WaterSample.GetWaterSamplesForUserAsync(userId, waterSampleParameters, trackChanges);

            var waterSamplesToReturn = _mapper.Map<IEnumerable<WaterSampleDto>>(waterSamplesWithMetaData);

            return (waterSamplesToReturn, metaData: waterSamplesWithMetaData.MetaData);
        }

        public async Task SaveChangesForPatchAsync(WaterSampleForUpdateDto waterSampleForPatch, WaterSample waterSampleEntity)
        {
            _mapper.Map(waterSampleForPatch, waterSampleEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateWaterSampleForUserAsync(Guid userId, Guid id, WaterSampleForUpdateDto waterSampleForUpdate, bool waterSampleTrackChanges)
        {
            await CheckIfUserExistsAsync(userId);

            var waterSampleEntity = await CheckIfWaterSampleExistsAndReturnItAsync(userId, id, waterSampleTrackChanges);

            _mapper.Map(waterSampleForUpdate, waterSampleEntity);

            await _repository.SaveAsync();
        }
    }
}
