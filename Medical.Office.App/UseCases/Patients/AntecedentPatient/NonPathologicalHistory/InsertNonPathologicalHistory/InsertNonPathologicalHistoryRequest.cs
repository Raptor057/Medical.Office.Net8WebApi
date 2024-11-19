using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory
{
    public sealed record InsertNonPathologicalHistoryRequest(
        long IDPatient,
        bool? PhysicalActivity,
        bool? Smoking,
        bool? Alcoholism,
        bool? SubstanceAbuse,
        string? SubstanceAbuseData,
        bool? RecentVaccination,
        string? RecentVaccinationData,
        bool? Others,
        string? OthersData) : IRequest<InsertNonPathologicalHistoryResponse>;
}
