using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground.Response;

public record FailureUpdatePathologicalBackgroundResponse(string Message) : UpdatePathologicalBackgroundResponse, IFailure;