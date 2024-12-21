using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

public record FailureUpdateFamilyHistoryResponse(string Message) : UpdateFamilyHistoryResponse, IFailure;