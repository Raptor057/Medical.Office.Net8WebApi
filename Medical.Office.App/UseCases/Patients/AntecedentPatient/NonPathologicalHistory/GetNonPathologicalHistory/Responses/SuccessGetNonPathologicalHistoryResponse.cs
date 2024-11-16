using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses
{
    public record SuccessGetNonPathologicalHistoryResponse(NonPathologicalHistoryDto NonPathologicalHistory) : GetNonPathologicalHistoryResponse, ISuccess;
}
