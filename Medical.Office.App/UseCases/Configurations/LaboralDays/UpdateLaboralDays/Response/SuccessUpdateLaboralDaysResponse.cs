using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays.Response
{
    public record SuccessUpdateLaboralDaysResponse(LaboralDaysDto UpdateLaboralDay): UpdateLaboralDaysResponse ,ISuccess;
}
