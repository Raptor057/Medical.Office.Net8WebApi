using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;

public record FailureUpdatePatientAllergiesResponse(string Message) : UpdatePatientAllergiesResponse,IFailure;