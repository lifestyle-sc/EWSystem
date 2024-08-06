using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public abstract record WaterSampleForManipulationDto
    {
        [Required(ErrorMessage = "Turbidity is a required field.")]
        public decimal Turbidity { get; init; }

        [Required(ErrorMessage = "Color is a required field.")]
        public string? Color { get; init; }

        [Required(ErrorMessage = "Odor is a required field.")]
        public string? Odor { get; init; }

        [Required(ErrorMessage = "Temperature is a required field.")]
        public decimal Temperature { get; init; }

        [Required(ErrorMessage = "PH is a required field.")]
        public decimal PH { get; init; }

        [Required(ErrorMessage = "Nitrates is a required field.")]
        public decimal Nitrates { get; init; }

        [Required(ErrorMessage = "Phosphates is a required field.")]
        public decimal Phosphates { get; init; }

        [Required(ErrorMessage = "Ammonia is a required field.")]
        public decimal Ammonia { get; init; }

        [Required(ErrorMessage = "Chlorine residual is a required field.")]
        public decimal ChlorineResidual { get; init; }

        [Required(ErrorMessage = "Heavy metals is a required field.")]
        public decimal HeavyMetals { get; init; }

        [Required(ErrorMessage = "COD is a required field.")]
        public decimal COD { get; init; }

        [Required(ErrorMessage = "BOD is a required field.")]
        public decimal BOD { get; init; }

        [Required(ErrorMessage = "Total coliforms is a required field.")]
        public decimal TotalColiforms { get; init; }

        [Required(ErrorMessage = "Fecal coliforms is a required field.")]
        public decimal FecalColiforms { get; init; }

        [Required(ErrorMessage = "Enterococci is a required field.")]
        public decimal Enterococci { get; init; }

        [Required(ErrorMessage = "Pathogenic bacteria is a required field.")]
        public string? PathogenicBacteria { get; init; }

        [Required(ErrorMessage = "Viruses is a required field.")]
        public string? Viruses { get; init; }

        [Required(ErrorMessage = "Protozoa or Helminths is a required field.")]
        public string? ProtozoaOrHelminths { get; init; }

        [Required(ErrorMessage = "TDS is a required field.")]
        public decimal TDS { get; init; }

        [Required(ErrorMessage = "Alkalinity is a required field.")]
        public decimal Alkalinity { get; init; }

        [Required(ErrorMessage = "Hardness is a required field.")]
        public decimal Hardness { get; init; }
        public decimal Probability { get; init; }

    }
}
