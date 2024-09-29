using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.InsertPatientData.Responses
{
    public record SuccessInsertPatientDataResponse(InsertPatientsDto InsertPatients): InsertPatientDataResponse;
}
