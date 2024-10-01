namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory
{
    public record FamilyHistoryDto(
        long Id,
        long IDPatient,
        bool? Diabetes,
        bool? Cardiopathies,
        bool? Hypertension,
        bool? ThyroidDiseases,
        bool? ChronicKidneyDisease,
        bool? Others,
        string OthersData,
        DateTime? DateTimeSnap
    );
}
