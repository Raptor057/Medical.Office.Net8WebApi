using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory
{
    public sealed record InsertPsychiatricHistoryRequest(
        long IDPatient,
        bool? FamilyHistory,
        string FamilyHistoryData,
        string AffectedAreas,
        string PastAndCurrentTreatments,
        bool? FamilySocialSupport,
        string FamilySocialSupportData,
        string WorkLifeAspects,
        string SocialLifeAspects,
        string AuthorityRelationship,
        string ImpulseControl,
        string FrustrationManagement) : IRequest<InsertPsychiatricHistoryResponse>;
}
