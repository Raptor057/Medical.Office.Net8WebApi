namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    public sealed class InsertFamilyHistoryRequestBody
    {
        public long IDPatient { get; set; }
        public bool? Diabetes { get; set; }
        public bool? Cardiopathies { get; set; }
        public bool? Hypertension { get; set; }
        public bool? ThyroidDiseases { get; set; }
        public bool? ChronicKidneyDisease { get; set; }
        public bool? Others { get; set; }
        public string? OthersData { get; set; }
    }
}
