using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory
{
    public sealed record GetPsychiatricHistoryRequest(long IdPatient) : IRequest<GetPsychiatricHistoryResponse>;
}
