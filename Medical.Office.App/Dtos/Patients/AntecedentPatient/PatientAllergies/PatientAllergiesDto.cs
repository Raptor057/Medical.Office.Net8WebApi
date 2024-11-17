namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies
{
    public record PatientAllergiesDto(
        long Id,
        long IDPatient,
        string? Allergies,
        DateTime? DateTimeSnap
    );
}
