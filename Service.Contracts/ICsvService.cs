namespace Service.Contracts
{
    public interface ICsvService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file);
    }
}
