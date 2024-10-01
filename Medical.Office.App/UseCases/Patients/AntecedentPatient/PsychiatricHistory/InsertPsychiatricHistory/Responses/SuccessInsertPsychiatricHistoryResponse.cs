using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory.Responses
{
    public record SuccessInsertPsychiatricHistoryResponse(PsychiatricHistoryDto PsychiatricHistoryDto) : InsertPsychiatricHistoryResponse;
}
