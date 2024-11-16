using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    public sealed record InsertMedicalHistoryNotesRequest(
        long IDPatient,
        string? MedicalHistoryNotesData) : IRequest<InsertMedicalHistoryNotesResponse>;
}
