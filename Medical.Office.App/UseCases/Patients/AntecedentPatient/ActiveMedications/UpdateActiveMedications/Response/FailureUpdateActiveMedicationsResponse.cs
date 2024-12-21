using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;

public record FailureUpdateActiveMedicationsResponse(string Message) : UpdateActiveMedicationsResponse, IFailure;