namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory
{
    public record NonPathologicalHistoryDto(
        long Id,
        long IDPatient,
        bool? PhysicalActivity,
        bool? Smoking,
        bool? Alcoholism,
        bool? SubstanceAbuse,
        string SubstanceAbuseData,
        bool? RecentVaccination,
        string RecentVaccinationData,
        bool? Others,
        string OthersData,
        DateTime? DateTimeSnap
    );
}
