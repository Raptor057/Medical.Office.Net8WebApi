using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory
{
    public sealed class GetPsychiatricHistoryRequest : IRequest<GetPsychiatricHistoryResponse>
    {
        public GetPsychiatricHistoryRequest()
        {
            
        }
        public long IdPatient { get; set; }
    }
}
