namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory
{
    public class InsertPsychiatricHistoryRequestBody
    {
        public long IDPatient { get; set; }
        public bool? FamilyHistory { get; set; }
        public string? FamilyHistoryData { get; set; }
        public string? AffectedAreas { get; set; }
        public string? PastAndCurrentTreatments { get; set; }
        public bool? FamilySocialSupport { get; set; }
        public string? FamilySocialSupportData { get; set; }
        public string? WorkLifeAspects { get; set; }
        public string? SocialLifeAspects { get; set; }
        public string? AuthorityRelationship { get; set; }
        public string? ImpulseControl { get; set; }
        public string? FrustrationManagement { get; set; }
    }
}
