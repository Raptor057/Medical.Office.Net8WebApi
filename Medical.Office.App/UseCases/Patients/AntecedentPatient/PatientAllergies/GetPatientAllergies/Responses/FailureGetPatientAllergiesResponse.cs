using Common.Common;
using Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses
{
    public record FailureGetPatientAllergiesResponse(string Message):GetPatientAllergiesResponse,IFailure;
}
