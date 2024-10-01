using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory.Responses
{
    public record SuccessGetFamilyHistoryResponse(FamilyHistoryDto FamilyHistoryDto) : GetFamilyHistoryResponse;
}
