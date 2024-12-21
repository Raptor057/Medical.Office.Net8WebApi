using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.UpdateMedicalHistoryNotes.Response;

public record SuccessMedicalHistoryNotesResponse(MedicalHistoryNotesDto MedicalHistoryNotes) : UpdateMedicalHistoryNotesResponse, ISuccess;