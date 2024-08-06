namespace Contracts
{
    public interface IRepositoryManager
    {
        ICandidateRepository Candidate { get; }

        IPollRepository Poll { get; }

        IWaterSampleRepository WaterSample { get; }

        Task SaveAsync();
    }
}
