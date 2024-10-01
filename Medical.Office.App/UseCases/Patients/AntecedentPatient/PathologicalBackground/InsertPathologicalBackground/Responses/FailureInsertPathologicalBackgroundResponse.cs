using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground.Responses
{
    public record FailureInsertPathologicalBackgroundResponse(string Message): InsertPathologicalBackgroundResponse,IFailure;
}
