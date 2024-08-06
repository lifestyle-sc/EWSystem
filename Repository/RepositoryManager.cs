using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IWaterSampleRepository> _waterSampleRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _waterSampleRepository = new Lazy<IWaterSampleRepository>(() => new WaterSampleRepository(_repositoryContext));
        }

        public IWaterSampleRepository WaterSample => _waterSampleRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
