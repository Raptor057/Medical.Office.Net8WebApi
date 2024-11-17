using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses
{
    public record SuccessGetPatientAllergiesResponse(PatientAllergiesDto PatientAllergies) : GetPatientAllergiesResponse, ISuccess;
}
