namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes
{
    public record MedicalHistoryNotesDto(
        long Id,
        long IDPatient,
        string? MedicalHistoryNotesData,
        DateTime? DateTimeSnap
    );
}
