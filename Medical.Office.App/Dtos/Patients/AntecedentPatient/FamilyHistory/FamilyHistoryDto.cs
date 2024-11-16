namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory
{
    public record FamilyHistoryDto(
        long Id,
        long IDPatient,
        int? Diabetes,
        int? Cardiopathies,
        int? Hypertension,
        int? ThyroidDiseases,
        int? ChronicKidneyDisease,
        int? Others,
        string? OthersData,
        DateTime? DateTimeSnap
    );
}
