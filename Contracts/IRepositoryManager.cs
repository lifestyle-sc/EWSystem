namespace Contracts
{
    public interface IRepositoryManager
    {
        IWaterSampleRepository WaterSample { get; }

        Task SaveAsync();
    }
}
