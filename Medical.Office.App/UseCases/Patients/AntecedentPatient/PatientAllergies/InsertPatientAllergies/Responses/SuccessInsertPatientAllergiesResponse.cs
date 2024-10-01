using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies.Responses
{
    public record SuccessInsertPatientAllergiesResponse(PatientAllergiesDto PatientAllergiesDto) : InsertPatientAllergiesResponse;
}
