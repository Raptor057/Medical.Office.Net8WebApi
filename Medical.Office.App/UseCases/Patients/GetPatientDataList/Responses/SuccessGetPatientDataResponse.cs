using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses
{
    public record SuccessGetPatientDataResponse(GetPatientsDto GetPatientsDto): GetPatientDataListResponse;
}
