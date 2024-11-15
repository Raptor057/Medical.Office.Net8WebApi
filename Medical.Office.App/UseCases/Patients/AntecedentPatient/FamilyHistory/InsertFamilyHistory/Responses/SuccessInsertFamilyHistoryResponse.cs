using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses
{
    public record SuccessInsertFamilyHistoryResponse(FamilyHistoryDto FamilyHistoryDto) : InsertFamilyHistoryResponse, ISuccess;
}
