using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses
{
    public record SuccessGetPsychiatricHistoryResponse(PsychiatricHistoryDto PsychiatricHistory): GetPsychiatricHistoryResponse, ISuccess;
}
