using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    public sealed record InsertFamilyHistoryRequest(
        long IDPatient,
        int? Diabetes,
        int? Cardiopathies,
        int? Hypertension,
        int? ThyroidDiseases,
        int? ChronicKidneyDisease,
        int? Others,
        string? OthersData)
        : IRequest<InsertFamilyHistoryResponse>;
}
