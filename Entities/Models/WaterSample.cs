using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class WaterSample : BaseEntity
    {
        [Column("SampleId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Turbidity is a required field.")]
        public decimal Turbidity { get; set; }

        [Required(ErrorMessage = "Color is a required field.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Odor is a required field.")]
        public string? Odor { get; set; }

        [Required(ErrorMessage = "Temperature is a required field.")]
        public decimal Temperature { get; set; }

        [Required(ErrorMessage = "PH is a required field.")]
        public decimal PH { get; set; }

        [Required(ErrorMessage = "Nitrates is a required field.")]
        public decimal Nitrates { get; set; }

        [Required(ErrorMessage = "Nitrites is a required field.")]
        public decimal Nitrites { get; set; }

        [Required(ErrorMessage = "Phosphates is a required field.")]
        public decimal Phosphates { get; set; }

        [Required(ErrorMessage = "Ammonia is a required field.")]
        public decimal Ammonia { get; set; }

        [Required(ErrorMessage = "Chlorine residual is a required field.")]
        public decimal ChlorineResidual { get; set; }

        [Required(ErrorMessage = "Heavy metals is a required field.")]
        public decimal HeavyMetals { get; set; }

        [Required(ErrorMessage = "COD is a required field.")]
        public decimal COD { get; set; }

        [Required(ErrorMessage = "BOD is a required field.")]
        public decimal BOD { get; set; }

        [Required(ErrorMessage = "Total coliforms is a required field.")]
        public decimal TotalColiforms { get; set; }

        [Required(ErrorMessage = "Fecal coliforms is a required field.")]
        public decimal FecalColiforms { get; set; }

        [Required(ErrorMessage = "Enterococci is a required field.")]
        public decimal Enterococci { get; set; }

        [Required(ErrorMessage = "Pathogenic bacteria is a required field.")]
        public string? PathogenicBacteria { get; set; }

        [Required(ErrorMessage = "Viruses is a required field.")]
        public string? Viruses { get; set; }

        [Required(ErrorMessage = "Protozoa or Helminths is a required field.")]
        public string? ProtozoaOrHelminths { get; set; }

        [Required(ErrorMessage = "TDS is a required field.")]
        public decimal TDS { get; set; }

        [Required(ErrorMessage = "Conductivity is a required field.")]
        public decimal Conductivity { get; set; }

        [Required(ErrorMessage = "Alkalinity is a required field.")]
        public decimal Alkalinity { get; set; }

        [Required(ErrorMessage = "Hardness is a required field.")]
        public decimal Hardness { get; set; }
        public decimal Probability { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

    }
}
