using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class WaterSampleConfiguration : IEntityTypeConfiguration<WaterSample>
    {
        public void Configure(EntityTypeBuilder<WaterSample> builder)
        {
            builder.HasIndex(x => x.Id);
        }
    }
}
