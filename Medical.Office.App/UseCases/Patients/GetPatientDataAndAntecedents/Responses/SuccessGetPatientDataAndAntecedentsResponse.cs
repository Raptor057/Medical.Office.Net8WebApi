using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents.Responses
{
    public record SuccessGetPatientDataAndAntecedentsResponse(PatientDataAndAntecedentsDto patientDataAndAntecedents) : GetPatientDataAndAntecedentsResponse, ISuccess;
}
