using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes
{
    public sealed class GetMedicalHistoryNotesRequest : IRequest<GetMedicalHistoryNotesResponse>
    {
        public GetMedicalHistoryNotesRequest()
        { }
        public long IdPatient { get; set; }
    }
}
