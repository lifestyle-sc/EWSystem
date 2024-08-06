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

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Turbidity)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Temperature)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.PH)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Nitrates)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Nitrites)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Phosphates)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Ammonia)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.ChlorineResidual)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.HeavyMetals)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.COD)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.BOD)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.TotalColiforms)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.FecalColiforms)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Enterococci)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.TDS)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Conductivity)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Alkalinity)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Hardness)
                .HasColumnType("decimal(18, 5)");

            builder.Property(x => x.Probability)
                .HasColumnType("decimal(18, 5)");
        }
    }
}
