using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPollRepository> _pollRepository;
        private readonly Lazy<ICandidateRepository> _candidateRepository;
        private readonly Lazy<IWaterSampleRepository> _waterSampleRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pollRepository = new Lazy<IPollRepository>(() => new PollRepository(_repositoryContext));
            _candidateRepository = new Lazy<ICandidateRepository>(() => new CandidateRepository(_repositoryContext));
            _waterSampleRepository = new Lazy<IWaterSampleRepository>(() => new WaterSampleRepository(_repositoryContext));
        }

        public IPollRepository Poll => _pollRepository.Value;

        public ICandidateRepository Candidate => _candidateRepository.Value;

        public IWaterSampleRepository WaterSample => _waterSampleRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
