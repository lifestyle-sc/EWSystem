namespace Shared.RequestFeatures
{
    public class WaterSampleParameters : RequestParameters
    {
        public WaterSampleParameters() => OrderBy = "createdAt";
        public string? SearchTerm { get; set; }
    }
}
