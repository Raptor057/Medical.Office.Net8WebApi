using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays.Response
{
    public record FailureUpdateLaboralDaysResponse(string Message) : UpdateLaboralDaysResponse, IFailure; 

}
