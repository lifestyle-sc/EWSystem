using Shared.DTOs;
using System.Text;

namespace EWApp.Formatter
{
    public class WaterSampleCsvOutputFormatter : CsvOutputFormatterBase<WaterSampleDto>
    {
        public WaterSampleCsvOutputFormatter()
        {
            
        }

        protected override void FormatCsv(StringBuilder buffer, WaterSampleDto entityDto)
        {
            buffer.AppendLine($"{entityDto.Id}, \" {entityDto.Turbidity}, \" {entityDto.Color}, \" {entityDto.Odor}, \" {entityDto.Temperature}, \" {entityDto.PH}," +
                $" \" {entityDto.Nitrates}, \" {entityDto.Nitrites}, \" {entityDto.Phosphates}, \" {entityDto.Ammonia}, \" {entityDto.ChlorineResidual}, \" {entityDto.HeavyMetals}, " +
                $"\" {entityDto.COD}, \" {entityDto.BOD}, \" {entityDto.TotalColiforms}, \" {entityDto.FecalColiforms}," +
                $" \" {entityDto.Enterococci}, \" {entityDto.PathogenicBacteria}, \" {entityDto.Viruses}, \" {entityDto.ProtozoaOrHelminths}," +
                $" \" {entityDto.TDS}, \" {entityDto.Conductivity}, \" {entityDto.Alkalinity} {entityDto.Hardness}, \" {entityDto.Probability}, \" {entityDto.CreatedAt}, \" {entityDto.UpdatedAt} \"");
        }
    }
}
