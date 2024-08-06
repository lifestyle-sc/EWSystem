using Entities.Models;

namespace Entities.Exceptions
{
    public class WaterSampleNotFoundException : NotFoundException
    {
        public WaterSampleNotFoundException(Guid sampleId) : base($"The sample with Id: {sampleId} doesn't exist in the database.")
        {
            
        }
    }
}
