using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record WaterSampleDto : BaseEntityDto
    {
        public Guid Id { get; set; }

        public decimal Turbidity { get; init; }

        public string? Color { get; init; }

        public string? Odor { get; init; }

        public decimal Temperature { get; init; }

        public decimal PH { get; init; }

        public decimal Nitrates { get; init; }

        public decimal Phosphates { get; init; }

        public decimal Ammonia { get; init; }

        public decimal ChlorineResidual { get; init; }

        public decimal HeavyMetals { get; init; }

        public decimal COD { get; init; }

        public decimal BOD { get; init; }

        public decimal TotalColiforms { get; init; }

        public decimal FecalColiforms { get; init; }

        public decimal Enterococci { get; init; }

        public string? PathogenicBacteria { get; init; }

        public string? Viruses { get; init; }

        public string? ProtozoaOrHelminths { get; init; }

        public decimal TDS { get; init; }

        public decimal Alkalinity { get; init; }

        public decimal Hardness { get; init; }
        public decimal Probability { get; init; }
    }
}
