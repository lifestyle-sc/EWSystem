using CsvHelper;
using Service.Contracts;
using System.Globalization;

namespace Service
{
    public class CsvService : ICsvService
    {
        public CsvService()
        {

        }
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
