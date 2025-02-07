﻿namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory
{
    public record PsychiatricHistoryDto(
    long Id,
    long IDPatient,
    bool? FamilyHistory,
    string? FamilyHistoryData,
    string? AffectedAreas,
    string? PastAndCurrentTreatments,
    bool? FamilySocialSupport,
    string? FamilySocialSupportData,
    string? WorkLifeAspects,
    string? SocialLifeAspects,
    string? AuthorityRelationship,
    string? ImpulseControl,
    string? FrustrationManagement,
    DateTime? DateTimeSnap
)
    {
        public PsychiatricHistoryDto(
            long IDPatient,
            bool? FamilyHistory,
            string? FamilyHistoryData,
            string? AffectedAreas,
            string? PastAndCurrentTreatments,
            bool? FamilySocialSupport,
            string? FamilySocialSupportData,
            string? WorkLifeAspects,
            string? SocialLifeAspects,
            string? AuthorityRelationship,
            string? ImpulseControl,
            string? FrustrationManagement,
            DateTime? DateTimeSnap
        ) : this(0, IDPatient, FamilyHistory, FamilyHistoryData, AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData, WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl, FrustrationManagement, DateTimeSnap)
        { }
    }
}