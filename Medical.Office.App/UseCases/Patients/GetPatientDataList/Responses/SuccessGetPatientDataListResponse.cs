using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses
{
    public record SuccessGetPatientDataListResponse(GetPatientsDtoList GetPatientsDtoList): GetPatientDataListResponse;
    public record SuccessGetShortPatientDataListResponse(GetShortPatientsDtoList GetShortPatientsDtoList): GetPatientDataListResponse;
}
