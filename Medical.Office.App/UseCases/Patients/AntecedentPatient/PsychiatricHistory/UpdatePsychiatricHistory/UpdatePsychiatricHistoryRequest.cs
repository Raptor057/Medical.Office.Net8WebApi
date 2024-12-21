using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory.Response;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory;

public record class UpdatePsychiatricHistoryRequest(PsychiatricHistoryDto PsychiatricHistory) : IRequest<UpdatePsychiatricHistoryResponse>;