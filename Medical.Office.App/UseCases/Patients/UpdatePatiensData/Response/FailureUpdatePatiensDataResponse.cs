using Common.Common;

namespace Medical.Office.App.UseCases.Patients.UpdatePatiensData.Response;

public record FailureUpdatePatiensDataResponse(string Message) : UpdatePatiensDataResponse, IFailure;