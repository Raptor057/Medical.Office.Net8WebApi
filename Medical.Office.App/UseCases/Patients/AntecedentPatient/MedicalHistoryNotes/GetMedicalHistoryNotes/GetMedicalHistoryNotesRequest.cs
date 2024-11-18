using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes
{
    public sealed record GetMedicalHistoryNotesRequest(long IdPatient) : IRequest<GetMedicalHistoryNotesResponse>;
}
