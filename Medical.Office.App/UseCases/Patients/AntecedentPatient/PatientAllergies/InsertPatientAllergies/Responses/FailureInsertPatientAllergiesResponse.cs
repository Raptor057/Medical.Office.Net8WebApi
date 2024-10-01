using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies.Responses
{
    public record FailureInsertPatientAllergiesResponse(string Message) : InsertPatientAllergiesResponse, IFailure;
}
