using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes.Response;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes;

public record UpdateMedicalHistoryNotesRequest(MedicalHistoryNotesDto MedicalHistoryNotes) : IRequest<UpdateMedicalHistoryNotesResponse>;