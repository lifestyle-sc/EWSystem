namespace Entities.Exceptions
{
    public class WaterSampleBadRequestException : BadRequestException
    {
        public WaterSampleBadRequestException() : base("Waterborne sample property collection is null")
        {
            
        }
    }
}
