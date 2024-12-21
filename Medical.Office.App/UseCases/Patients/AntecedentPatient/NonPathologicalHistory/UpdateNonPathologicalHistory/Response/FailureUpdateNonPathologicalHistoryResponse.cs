using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory.Response;

public record FailureUpdateNonPathologicalHistoryResponse(string Message) : UpdateNonPathologicalHistoryResponse, IFailure;