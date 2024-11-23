using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    public sealed record InsertFamilyHistoryRequest(
        long IDPatient,
        bool? Diabetes,
        bool? Cardiopathies,
        bool? Hypertension,
        bool? ThyroidDiseases,
        bool? ChronicKidneyDisease,
        bool? Others,
        string? OthersData)
        : IRequest<InsertFamilyHistoryResponse>;
}
