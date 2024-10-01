using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses
{
    public record FailureGetPathologicalBackgroundResponse(string Message) : GetPathologicalBackgroundResponse,IFailure;
}
